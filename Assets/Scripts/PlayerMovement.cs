// PlayerController.cs
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PathConteiner _pathConteiner;
    
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float pauseBetweenCircles = 0.1f;
    public bool canMoveBackwards = true;
    public bool isMoving = false;
        

    public void MoveToPathPoint(Path playerPath, PathPoint target, int currentPositionIndex)
    {
        if (target != null)
        {           
            
            StartCoroutine(MoveAlongPath(target.PositionNumber, playerPath.PathPoints, currentPositionIndex));
          
        }
    }

    private IEnumerator MoveAlongPath(int targetIndex, List<PathPoint> pathPoints, int currentPositionIndex)
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
            Vector3 endPos = pathPoints[nextIndex].transform.position;
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

    public bool IsMoving()
    {
        return isMoving;
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