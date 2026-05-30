// PathCircle.cs
using System;
using UnityEngine;

public class PathPoint : Point
{
    [SerializeField] private int _numberSize = 20;
    [SerializeField] private float _numberWidth = 0.3f;
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();

    public override void PointAction()
    {
        Game.Instance.PlayerUnSelect();
        saveLoader.Save(gameData.GetPlayerData());
    }


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

    protected override void Start()
    {
        base.Start();
        CreateNumberText();
    }
}