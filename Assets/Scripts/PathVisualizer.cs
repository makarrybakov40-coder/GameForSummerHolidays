// PathVisualizer.cs
using UnityEngine;
using System.Collections.Generic;

public class PathVisualizer : MonoBehaviour
{
    [Header("Настройки визуализации")]
    public Color lineColor = Color.green;
    public float lineWidth = 0.1f;
    public bool showNumbers = true;

    private List<Transform> circles = new List<Transform>();
    private LineRenderer lineRenderer;

    void Start()
    {
        InitializeLineRenderer();
        UpdatePath();
    }

    void InitializeLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // Обновляем путь при изменении в редакторе
        if (Application.isEditor)
        {
            UpdatePath();
        }
    }

    public void UpdatePath()
    {
        // Получаем все круги пути
        circles.Clear();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<PathCircle>() != null)
            {
                circles.Add(child);
            }
        }

        // Сортируем по номеру
        circles.Sort((a, b) =>
            a.GetComponent<PathCircle>().circleNumber.CompareTo(
            b.GetComponent<PathCircle>().circleNumber));

        // Обновляем LineRenderer
        if (lineRenderer != null && circles.Count > 1)
        {
            lineRenderer.positionCount = circles.Count;
            for (int i = 0; i < circles.Count; i++)
            {
                lineRenderer.SetPosition(i, circles[i].position);
            }
        }
    }

    // Метод для добавления в PathManager
    public List<Transform> GetPathTransforms()
    {
        return circles;
    }
}