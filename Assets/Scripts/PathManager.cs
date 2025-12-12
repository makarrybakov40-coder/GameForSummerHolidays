// PathManager.cs
using UnityEngine;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{
    [Header("Настройки пути")]
    public GameObject circlePrefab;
    public int numberOfCircles = 10;
    public float circleSpacing = 1.5f;
    public Vector2 startPosition = Vector2.zero;
    public bool curvedPath = false; // Прямой или изогнутый путь

    [Header("Ссылки")]
    public PlayerMovement playerController;
    public PathVisualizer pathVisualizer;

    private List<Transform> pathPoints = new List<Transform>();

    void Start()
    {
        GeneratePath();

        // Передаем путь игроку
        if (playerController != null)
        {
            playerController.SetPath(pathPoints);
        }

        // Обновляем визуализатор
        if (pathVisualizer != null)
        {
            pathVisualizer.UpdatePath();
        }
    }

    void GeneratePath()
    {
        // Очищаем старые круги
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        pathPoints.Clear();

        // Создаем новый путь
        for (int i = 0; i < numberOfCircles; i++)
        {
            Vector2 position;

            if (curvedPath && i > 0)
            {
                // Немного изгибаем путь для красоты
                float angle = Mathf.Sin(i * 0.3f) * 0.5f;
                position = startPosition + new Vector2(
                    i * circleSpacing,
                    Mathf.Sin(i * 0.5f) * 0.8f
                );
            }
            else
            {
                // Прямой путь
                position = startPosition + new Vector2(i * circleSpacing, 0);
            }

            // Создаем круг
            GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity, transform);
            circle.name = $"PathCircle_{i + 1}";

            // Настраиваем компонент круга
            PathCircle pathCircle = circle.GetComponent<PathCircle>();
            if (pathCircle != null)
            {
                pathCircle.SetCircleNumber(i + 1);
            }

            // Добавляем коллайдер
            CircleCollider2D collider = circle.GetComponent<CircleCollider2D>();
            if (collider == null)
            {
                collider = circle.AddComponent<CircleCollider2D>();
                collider.radius = 0.4f;
            }

            // Добавляем в список
            pathPoints.Add(circle.transform);
        }
    }

    // Редакторная функция для перегенерации пути
    [ContextMenu("Regenerate Path")]
    void RegeneratePath()
    {
        GeneratePath();
        if (pathVisualizer != null)
        {
            pathVisualizer.UpdatePath();
        }
    }

    // Автоматическое обновление при изменении в инспекторе
    void OnValidate()
    {
        if (Application.isPlaying) return;

        // Здесь можно добавить предпросмотр в редакторе
    }
}