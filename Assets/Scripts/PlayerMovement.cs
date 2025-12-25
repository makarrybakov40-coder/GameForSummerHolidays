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

    Player player;

    private List<Transform> pathPoints;

    private int currentPositionIndex;

    public bool isMoving = false;


    void Start()
    {

        player = GetComponent<Player>();
        pathPoints = player.pathPoints;
        currentPositionIndex = player.currentPositionIndex;
        player.MoveAlongPath(0);
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
                    if (canMoveBackwards == true) //|| clickedIndex > currentPositionIndex))
                    {
                        StartCoroutine(player.MoveAlongPath(clickedIndex));
                    }
                    else
                    {
                        Debug.Log("Нельзя двигаться назад!");
                    }
                }
            }
        }
    }


    //IEnumerator MoveAlongPath(int targetIndex)
    //{
    //    isMoving = true;

    //    // Определяем направление (1 = вперед, -1 = назад)
    //    int direction = (targetIndex > currentPositionIndex) ? 1 : -1;

    //    // Двигаемся по одному кругу
    //    while (currentPositionIndex != targetIndex)
    //    {
    //        int nextIndex = currentPositionIndex + direction;

    //        // Движение к следующему кругу
    //        Vector3 startPos = transform.position;
    //        Vector3 endPos = pathPoints[nextIndex].position;
    //        float distance = Vector3.Distance(startPos, endPos);
    //        float duration = distance / moveSpeed;

    //        float elapsedTime = 0f;
    //        while (elapsedTime < duration)
    //        {
    //            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
    //            elapsedTime += Time.deltaTime;
    //            yield return null;
    //        }

    //        // Точно ставим на круг
    //        transform.position = endPos;
    //        currentPositionIndex = nextIndex;

    //        // Небольшая пауза на круге
    //        yield return new WaitForSeconds(pauseBetweenCircles);
    //    }

    //    isMoving = false;
    //    Debug.Log($"Достигнут круг {currentPositionIndex + 1}");
    //}

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

}