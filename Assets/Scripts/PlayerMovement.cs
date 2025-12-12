// PlayerController.cs
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float delayBetweenPoints = 0.2f; // Задержка между кругами

    [Header("Ссылки")]
    public List<Transform> pathPoints = new List<Transform>();

    // Текущее состояние
    private int currentPositionIndex = 0;
    private int targetIndex = 0;
    private bool isMoving = false;
    private Coroutine moveCoroutine;

    void Start()
    {
        if (pathPoints.Count > 0)
        {
            // Устанавливаем игрока на первый круг
            transform.position = pathPoints[0].position;
            currentPositionIndex = 0;
            targetIndex = 0;
        }
    }

    void Update()
    {
        // Обработка клика мышью
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            PathCircle circle = hit.collider.GetComponent<PathCircle>();
            if (circle != null)
            {
                // Находим индекс целевого круга в пути
                int clickedIndex = pathPoints.IndexOf(circle.transform);

                if (clickedIndex != -1 && clickedIndex > currentPositionIndex)
                {
                    targetIndex = clickedIndex;

                    // Запускаем корутину для последовательного движения
                    if (moveCoroutine != null)
                        StopCoroutine(moveCoroutine);

                    moveCoroutine = StartCoroutine(MoveThroughPath());
                }
                else if (clickedIndex == currentPositionIndex)
                {
                    Debug.Log("Уже на этом круге!");
                }
                else if (clickedIndex < currentPositionIndex)
                {
                    Debug.Log("Можно двигаться только вперед!");
                }
            }
        }
    }

    IEnumerator MoveThroughPath()
    {
        isMoving = true;

        // Двигаемся от текущей позиции к целевой через все промежуточные круги
        for (int i = currentPositionIndex + 1; i <= targetIndex; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = pathPoints[i].position;
            float distance = Vector3.Distance(startPos, endPos);
            float duration = distance / moveSpeed;

            float elapsedTime = 0f;

            // Плавное движение к следующему кругу
            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);

                // Плавный поворот в направлении движения
                Vector3 direction = (endPos - transform.position).normalized;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Точно устанавливаем позицию на круге
            transform.position = endPos;
            currentPositionIndex = i;

            // Короткая пауза на круге (кроме последнего)
            if (i < targetIndex)
            {
                yield return new WaitForSeconds(delayBetweenPoints);
            }
        }

        isMoving = false;
        moveCoroutine = null;

        Debug.Log($"Достигнут круг {targetIndex + 1}");
    }

    // Метод для визуализации пути в редакторе
    void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Count < 2) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < pathPoints.Count - 1; i++)
        {
            if (pathPoints[i] != null && pathPoints[i + 1] != null)
            {
                Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
            }
        }

        // Показываем текущую позицию
        if (currentPositionIndex < pathPoints.Count && pathPoints[currentPositionIndex] != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pathPoints[currentPositionIndex].position, 0.3f);
        }
    }

    // Метод для установки пути (вызывается из PathManager)
    public void SetPath(List<Transform> points)
    {
        pathPoints = points;
        if (pathPoints.Count > 0)
        {
            currentPositionIndex = 0;
            targetIndex = 0;
            transform.position = pathPoints[0].position;
        }
    }

    // Метод для принудительной установки позиции
    public void SetPositionToCircle(int circleIndex)
    {
        if (circleIndex >= 0 && circleIndex < pathPoints.Count)
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);

            currentPositionIndex = circleIndex;
            targetIndex = circleIndex;
            transform.position = pathPoints[circleIndex].position;
            isMoving = false;
            moveCoroutine = null;
        }
    }

    // Публичные методы для получения состояния
    public int GetCurrentCircleNumber()
    {
        return currentPositionIndex + 1;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}