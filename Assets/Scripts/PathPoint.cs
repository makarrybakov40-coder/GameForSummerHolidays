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

    public void ConnectPointToPath(int playerID, int positionNumber)
    {
        _playerID = playerID;
        _positionNumber = positionNumber;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
        //SetNumber();
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

    //private void SetNumber()
    //{

    //    TextMesh textMesh = GetComponentInChildren<TextMesh>();
    //    if (textMesh != null)
    //    {
    //        textMesh.text = _positionNumber.ToString();
    //    }
    //}
}