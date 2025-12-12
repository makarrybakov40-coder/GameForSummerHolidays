// PathCircle.cs
using UnityEngine;

public class PathCircle : MonoBehaviour
{
    public int circleNumber = 1;
    public int pathIndex = 0;

    private SpriteRenderer sprite;
    private Color normalColor = Color.white;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        // Разные цвета для разных путей
        if (sprite != null)
        {
            float hue = pathIndex * 0.3f;
            normalColor = Color.HSVToRGB(hue, 0.3f, 1f);
            sprite.color = normalColor;
        }

        // Номер круга
        CreateNumberText();
    }

    void CreateNumberText()
    {
        GameObject textObj = new GameObject("Number");
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = Vector3.zero;

        TextMesh text = textObj.AddComponent<TextMesh>();
        text.text = circleNumber.ToString();
        text.fontSize = 20;
        text.characterSize = 0.05f;
        text.color = Color.black;
        text.anchor = TextAnchor.MiddleCenter;

        textObj.transform.localScale = Vector3.one * 0.5f;
    }

    void OnMouseEnter()
    {
        if (sprite != null) sprite.color = Color.yellow;
    }

    void OnMouseExit()
    {
        if (sprite != null) sprite.color = normalColor;
    }
}