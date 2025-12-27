using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(PlayerMovement))]

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

    private float moveSpeed;
    private float pauseBetweenCircles;

    PlayerMovement playerMovement;

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

    public void Move(PathPoint pathPoint) 
    {
        playerMovement.MoveToPathPoint(pathPoints, pathPoint);
    }

    private void Start()
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
