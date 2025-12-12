// PlayerController.cs
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float pauseBetweenCircles = 0.1f;
    public bool canMoveBackwards = true;

    [Header("Ссылки")]
    public List<Transform> pathPoints = new List<Transform>();

    // Визуальные настройки
    public Color playerColor = Color.red;
    public GameObject selectionIndicator;

    // Состояние
    private int currentPositionIndex = 0;
    private bool isMoving = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = playerColor;
        }

        if (pathPoints.Count > 0)
        {
            // Ставим на первый круг
            transform.position = pathPoints[0].position;
            currentPositionIndex = 0;
        }

        // Скрываем индикатор выбора
        if (selectionIndicator != null)
        {
            selectionIndicator.SetActive(false);
        }
    }

    void Update()
    {
        if (isMoving) return;

        // Клик для перемещения
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            PathCircle circle = hit.collider.GetComponent<PathCircle>();
            if (circle != null)
            {
                // Ищем этот круг в нашем пути
                int clickedIndex = -1;
                for (int i = 0; i < pathPoints.Count; i++)
                {
                    if (pathPoints[i] == circle.transform)
                    {
                        clickedIndex = i;
                        break;
                    }
                }

                if (clickedIndex != -1 && clickedIndex != currentPositionIndex)
                {
                    // Проверяем можно ли двигаться
                    if (canMoveBackwards || clickedIndex > currentPositionIndex)
                    {
                        StartCoroutine(MoveAlongPath(clickedIndex));
                    }
                    else
                    {
                        Debug.Log("Нельзя двигаться назад!");
                    }
                }
            }
        }
    }

    IEnumerator MoveAlongPath(int targetIndex)
    {
        isMoving = true;

        // Определяем направление (1 = вперед, -1 = назад)
        int direction = (targetIndex > currentPositionIndex) ? 1 : -1;

        // Двигаемся по одному кругу
        while (currentPositionIndex != targetIndex)
        {
            int nextIndex = currentPositionIndex + direction;

            // Движение к следующему кругу
            Vector3 startPos = transform.position;
            Vector3 endPos = pathPoints[nextIndex].position;
            float distance = Vector3.Distance(startPos, endPos);
            float duration = distance / moveSpeed;

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Точно ставим на круг
            transform.position = endPos;
            currentPositionIndex = nextIndex;

            // Небольшая пауза на круге
            yield return new WaitForSeconds(pauseBetweenCircles);
        }

        isMoving = false;
        Debug.Log($"Достигнут круг {currentPositionIndex + 1}");
    }

    // Публичные методы для управления

    public void SetPath(List<Transform> points)
    {
        pathPoints = points;
        if (pathPoints.Count > 0)
        {
            currentPositionIndex = 0;
            transform.position = pathPoints[0].position;
        }
    }

    public void SetActive(bool active)
    {
        if (selectionIndicator != null)
        {
            selectionIndicator.SetActive(active);
        }

        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = active ? 1f : 0.5f;
            spriteRenderer.color = color;
        }
    }

    public void SetColor(Color color)
    {
        playerColor = color;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public int GetCurrentCircle()
    {
        return currentPositionIndex;
    }

    public void TeleportToCircle(int circleIndex)
    {
        if (circleIndex >= 0 && circleIndex < pathPoints.Count)
        {
            currentPositionIndex = circleIndex;
            transform.position = pathPoints[circleIndex].position;
        }
    }

    // Для отладки в редакторе
    void OnDrawGizmos()
    {
        if (pathPoints.Count < 2) return;

        Gizmos.color = playerColor;

        // Рисуем линию пути
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
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(pathPoints[currentPositionIndex].position, 0.2f);
        }
    }
}