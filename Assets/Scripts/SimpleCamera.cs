// SimpleCamera.cs
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform[] players;
    public float smoothSpeed = 0.5f;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (players == null || players.Length == 0) return;

        // —редн€€ позици€ всех игроков
        Vector3 center = Vector3.zero;
        foreach (Transform player in players)
        {
            if (player != null) center += player.position;
        }
        center /= players.Length;

        // ѕлавное движение камеры
        Vector3 targetPosition = center + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}