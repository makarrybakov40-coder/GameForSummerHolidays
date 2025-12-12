// PlayerController.cs
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки")]
    public float moveSpeed = 3f;
    public bool canMoveBack = true;

    [Header("Данные игрока")]
    public int playerNumber = 1;
    public Color playerColor = Color.white;

    // Состояние
    public bool isMoving { get; private set; }
    public int currentCircle { get; private set; }

    // Путь
    private List<Transform> path = new List<Transform>();
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (sprite != null) sprite.color = playerColor;
        currentCircle = 0;
    }

    public void SetPath(List<Transform> newPath)
    {
        path = newPath;
        if (path.Count > 0)
        {
            transform.position = path[0].position;
            currentCircle = 0;
        }
    }

    public void HandleClick()
    {
        if (isMoving) return;

        // Проверяем клик по кругу
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            PathCircle circle = hit.collider.GetComponent<PathCircle>();
            if (circle != null)
            {
                // Находим индекс круга в пути
                int targetIndex = path.IndexOf(circle.transform);
                if (targetIndex != -1 && targetIndex != currentCircle)
                {
                    // Проверяем можно ли туда идти
                    if (canMoveBack || targetIndex > currentCircle)
                    {
                        StartCoroutine(MoveToCircle(targetIndex));
                    }
                }
            }
        }
    }

    IEnumerator MoveToCircle(int targetIndex)
    {
        isMoving = true;

        // Определяем направление
        int step = (targetIndex > currentCircle) ? 1 : -1;

        // Двигаемся по одному кругу
        while (currentCircle != targetIndex)
        {
            int nextCircle = currentCircle + step;

            // Двигаемся к следующему кругу
            Vector3 startPos = transform.position;
            Vector3 endPos = path[nextCircle].position;
            float distance = Vector3.Distance(startPos, endPos);
            float time = distance / moveSpeed;
            float elapsed = 0f;

            while (elapsed < time)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsed / time);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Точно встаем на круг
            transform.position = endPos;
            currentCircle = nextCircle;

            // Минимальная пауза на круге
            yield return new WaitForSeconds(0.1f);
        }

        isMoving = false;

        // Проверяем победу
        if (currentCircle == path.Count - 1)
        {
            Debug.Log($"Игрок {playerNumber} победил!");
        }
    }

    // Для телепортации (например, при спец-кругах)
    public void TeleportToCircle(int circleIndex)
    {
        if (circleIndex >= 0 && circleIndex < path.Count)
        {
            transform.position = path[circleIndex].position;
            currentCircle = circleIndex;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = playerColor;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}