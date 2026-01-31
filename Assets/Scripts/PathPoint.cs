// PathCircle.cs
using System;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    private int _playerID;
    private int _positionNumber;

    [Header("Настройки")]
    private Color normalColor = Color.white;
    private Color hoverColor = Color.yellow;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public int PlayerID {  get { return _playerID; } }
    public int PositionNumber { get { return _positionNumber; } }

    public void ConnectPointToPath(Path path)
    {
        _playerID = path.PlayerID;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    
    void OnMouseEnter()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
}