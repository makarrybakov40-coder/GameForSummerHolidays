// PlayerController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PathConteiner _pathConteiner;
    
    private bool isMoving = false;

    [Header("Настройки движения")]
    public float moveSpeed = 700f;
    public float pauseBetweenCircles = 0.1f;
    public bool canMoveBackwards = true;
    public bool IsMoving {  get { return isMoving; } }

    public void MoveToPathPoint(Path playerPath, Point target, int currentPositionIndex)
    {
        if (target != null)
        {           
            
            StartCoroutine(MoveAlongPath(target, playerPath.PathPoints, currentPositionIndex));
          
        }
    }

    private IEnumerator MoveAlongPath(Point target, List<Point> pathPoints, int currentPositionIndex)
    {
        isMoving = true;
        // Определяем направление (1 = вперед, -1 = назад)
        int direction = (target.PositionNumber > currentPositionIndex) ? 1 : -1;

        // Двигаемся по одному кругу
        while (currentPositionIndex != target.PositionNumber)
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
        target.PointAction();
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