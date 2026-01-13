// PlayerController.cs
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private int currentPositionIndex;
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float pauseBetweenCircles = 0.1f;
    public bool canMoveBackwards = true;
    public bool isMoving = false;

    [SerializeField] private Game game;


    private void Start()
    {           
        currentPositionIndex = 0;
    }

    public void MoveToPathPoint(List<Transform> pathPoints, PathPoint target)
    {
        if (target != null)
        {            
            int clickedIndex = 0;
            for (int i = 0; i < pathPoints.Count; i++)
            {
                if (pathPoints[i] == target.transform)
                {
                    clickedIndex = i;
                    break;
                }
            }

            if (clickedIndex != -1)
            {               
                if (canMoveBackwards == true || clickedIndex > currentPositionIndex)
                {
                    StartCoroutine(MoveAlongPath(clickedIndex, pathPoints));
                }
                else
                {
                    Debug.Log("Нельзя двигаться назад!");
                }
            }
        }
    }


    private IEnumerator MoveAlongPath(int targetIndex, List<Transform> pathPoints)
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
        game.ActivePlayer();
        game.PLayerUnSelect();
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public int GetCurrentCircle()
    {
        return currentPositionIndex;
    }

    //public void TeleportToCircle(int circleIndex)
    //{
    //    if (circleIndex >= 0 && circleIndex < pathPoints.Count)
    //    {
    //        currentPositionIndex = circleIndex;
    //        transform.position = pathPoints[circleIndex].position;
    //    }
    //}

}