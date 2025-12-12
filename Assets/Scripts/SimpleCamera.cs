// SimpleCameraController.cs
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public List<Transform> playersToFollow;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (playersToFollow == null || playersToFollow.Count == 0) return;

        // Находим среднюю позицию всех игроков
        Vector3 centerPosition = Vector3.zero;
        int activePlayers = 0;

        foreach (Transform player in playersToFollow)
        {
            if (player != null)
            {
                centerPosition += player.position;
                activePlayers++;
            }
        }

        if (activePlayers > 0)
        {
            centerPosition /= activePlayers;

            // Плавно двигаем камеру
            Vector3 desiredPosition = centerPosition + offset;
            Vector3 smoothedPosition = Vector3.Lerp(
                transform.position,
                desiredPosition,
                smoothSpeed * Time.deltaTime
            );

            transform.position = smoothedPosition;
        }
    }
}