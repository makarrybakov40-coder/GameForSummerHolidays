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

    [SerializeField] private int _numberSize = 20;
    [SerializeField] private float _numberWidth = 0.3f;
    [SerializeField] private bool _specialPoint;
    [SerializeField] private PathPoint _specialPointMoveTo;

    public int PlayerID {  get { return _playerID; } }
    public int PositionNumber { get { return _positionNumber; } }
    public bool SpecialPoint { get { return _specialPoint; } }
    public PathPoint SpecialPointMoveTo {  get { return _specialPointMoveTo; } }

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
        CreateNumberText();
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

    void CreateNumberText()
    {
        int positionNumber;
        positionNumber = _positionNumber;
        positionNumber++;
        // ������� GameObject ��� ������
        GameObject textObject = new GameObject("PointNumber");
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = Vector3.zero;

        // ��������� ��������� TextMesh
        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = positionNumber.ToString();
        textMesh.fontSize = _numberSize;
        textMesh.characterSize = _numberWidth;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.color = Color.black;

        // ��������� �������
        textObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    }
}