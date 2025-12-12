<<<<<<< HEAD
// SimpleCamera.cs
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform[] players;
    public float smoothSpeed = 0.5f;
=======
// SimpleCameraController.cs
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public List<Transform> playersToFollow;
    public float smoothSpeed = 5f;
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
<<<<<<< HEAD
        if (players == null || players.Length == 0) return;

        // Средняя позиция всех игроков
        Vector3 center = Vector3.zero;
        foreach (Transform player in players)
        {
            if (player != null) center += player.position;
        }
        center /= players.Length;

        // Плавное движение камеры
        Vector3 targetPosition = center + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
=======
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
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
    }
}