// PathManager.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PathManager : MonoBehaviour
{
    [Header("Настройки пути")]
    public GameObject circlePrefab;
    public int numberOfCircles = 10;
    public float circleSpacing = 1.5f;
    public Vector2 startPosition = Vector2.zero;

    [Header("Ссылки")]
    public PlayerMovement playerController;

    private List<Transform> pathPoints = new List<Transform>();

    void Start()
    {
        GeneratePath();

        // Передаем путь игроку
        if (playerController != null)
        {
            playerController.SetPath(pathPoints);
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
            Vector2 position = startPosition + new Vector2(i * circleSpacing, 0);

            // Создаем круг
            GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity, transform);
            circle.name = $"PathCircle_{i + 1}";

            // Настраиваем компонент круга
            PathCircle pathCircle = circle.GetComponent<PathCircle>();
            if (pathCircle != null)
            {
                pathCircle.SetCircleNumber(i + 1);
            }

            // Добавляем в список
            pathPoints.Add(circle.transform);
        }
    }

    // Метод для получения всех точек пути
    public List<Transform> GetPathPoints()
    {
        return pathPoints;
    }

    // Метод для получения точки по индексу
    public Transform GetPathPoint(int index)
    {
        if (index >= 0 && index < pathPoints.Count)
        {
            return pathPoints[index];
        }
        return null;
    }

    // Редакторная функция для перегенерации пути
    [ContextMenu("Regenerate Path")]
    void RegeneratePath()
    {
        GeneratePath();
    }
}