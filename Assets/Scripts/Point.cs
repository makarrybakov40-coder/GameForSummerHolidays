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
    //private void SetNumber()
    //{

    //    TextMesh textMesh = GetComponentInChildren<TextMesh>();
    //    if (textMesh != null)
    //    {
    //        textMesh.text = _positionNumber.ToString();
    //    }
    //}

    //void CreateNumberText()
    //{
    //    int positionNumber;
    //    positionNumber = _positionNumber;
    //    positionNumber++;
    //    // ������� GameObject ��� ������
    //    GameObject textObject = new GameObject("PointNumber");
    //    textObject.transform.SetParent(transform);
    //    textObject.transform.localPosition = Vector3.zero;

    //    // ��������� ��������� TextMesh
    //    TextMesh textMesh = textObject.AddComponent<TextMesh>();
    //    textMesh.text = positionNumber.ToString();
    //    textMesh.fontSize = _numberSize;
    //    textMesh.characterSize = _numberWidth;
    //    textMesh.anchor = TextAnchor.MiddleCenter;
    //    textMesh.alignment = TextAlignment.Center;
    //    textMesh.color = Color.black;

    //    // ��������� �������
    //    textObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    //}
}