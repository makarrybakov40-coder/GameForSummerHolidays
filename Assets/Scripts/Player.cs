using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ссылки")]
    public List<Transform> pathPoints = new List<Transform>();

    // Визуальные настройки
    public Color playerColor = Color.red;
    public GameObject selectionIndicator;

    // Состояние
    public int currentPositionIndex = 0;
    private bool isMoving;
    private SpriteRenderer spriteRenderer;

    PlayerMovement playerMovement;

    private float moveSpeed;
    private float pauseBetweenCircles;


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

        playerMovement = GetComponent<PlayerMovement>();
        moveSpeed = playerMovement.moveSpeed;
        pauseBetweenCircles = playerMovement.pauseBetweenCircles;
        isMoving = playerMovement.isMoving;
    }

    public IEnumerator MoveAlongPath(int targetIndex)
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
