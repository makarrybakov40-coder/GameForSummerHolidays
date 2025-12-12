// PathManager.cs
using UnityEngine;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{
    [Header("Основные настройки")]
    public GameObject circlePrefab;
    public int circlesPerPath = 10;
    public int numberOfPaths = 2;
    public float horizontalSpacing = 2f;
    public float verticalSpacing = 1.5f;

    private List<List<Transform>> allPaths = new List<List<Transform>>();

    void Start()
    {
        CreatePaths();
    }

    void CreatePaths()
    {
        // Очищаем старые круги
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        allPaths.Clear();

        // Создаем каждый путь
        for (int pathIndex = 0; pathIndex < numberOfPaths; pathIndex++)
        {
            List<Transform> path = new List<Transform>();

            for (int i = 0; i < circlesPerPath; i++)
            {
                // Позиция круга
                float x = i * horizontalSpacing;
                float y = pathIndex * verticalSpacing;
                Vector3 position = new Vector3(x, y, 0);

                // Создаем круг
                GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity, transform);
                circle.name = $"Path{pathIndex + 1}_Circle{i + 1}";

                // Настраиваем
                PathCircle pc = circle.GetComponent<PathCircle>();
                if (pc != null)
                {
                    pc.circleNumber = i + 1;
                    pc.pathIndex = pathIndex;
                }

                path.Add(circle.transform);
            }

            allPaths.Add(path);
        }
    }

    public List<Transform> GetPathForPlayer(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < allPaths.Count)
        {
            return allPaths[playerIndex];
        }
        return new List<Transform>();
    }

    public int GetPathLength()
    {
        return circlesPerPath;
    }

    // Для редактора
    [ContextMenu("Обновить пути")]
    void RegeneratePaths()
    {
        CreatePaths();
    }
}