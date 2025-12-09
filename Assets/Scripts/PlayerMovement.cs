// PlayerController.cs
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    [Header("Ссылки")]
    public List<Transform> pathPoints = new List<Transform>();

    // Текущее состояние
    private int currentTargetIndex = 0;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        if (pathPoints.Count > 0)
        {
            transform.position = pathPoints[0].position;
            currentTargetIndex = 0;
        }
    }

    void Update()
    {
        // Обработка клика мышью
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }

        // Движение к цели
        if (isMoving)
        {
            MoveToTarget();
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
                // Находим индекс целевого круга
                int targetIndex = pathPoints.IndexOf(circle.transform);

                if (targetIndex > currentTargetIndex)
                {
                    currentTargetIndex = targetIndex;
                    targetPosition = pathPoints[currentTargetIndex].position;
                    isMoving = true;
                }
            }
        }
    }

    void MoveToTarget()
    {
        // Движение к цели
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Поворот в направлении движения
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Проверка достижения цели
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }

    // Метод для установки пути (вызывается из PathManager)
    public void SetPath(List<Transform> points)
    {
        pathPoints = points;
        if (pathPoints.Count > 0)
        {
            transform.position = pathPoints[0].position;
        }
    }

    // Метод для принудительной установки позиции
    public void SetPositionToCircle(int circleIndex)
    {
        if (circleIndex >= 0 && circleIndex < pathPoints.Count)
        {
            currentTargetIndex = circleIndex;
            transform.position = pathPoints[circleIndex].position;
            isMoving = false;
        }
    }
}