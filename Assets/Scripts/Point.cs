// PathCircle.cs
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
abstract public class Point : MonoBehaviour
{
    [SerializeField] protected Sprite _pointSprite;

    protected int _playerID;
    protected int _positionNumber;   
    protected Color hoverColor = Color.yellow;
    protected SpriteRenderer _spriteRenderer;
    protected Color _originalColor;   

    public int PlayerID { get { return _playerID; } }
    public int PositionNumber { get { return _positionNumber; } }

    abstract public void PointAction();

    public void ConnectPointToPath(int playerID, int positionNumber)
    {
        _playerID = playerID;
        _positionNumber = positionNumber;
    }

    virtual protected void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        _spriteRenderer.sprite = _pointSprite;
    }


    private void OnMouseEnter()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _originalColor;
        }
    }

    protected void SetPointSprite(Sprite sprite)
    {
        _pointSprite = sprite;
    }
}