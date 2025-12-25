// PathCircle.cs
using UnityEngine;

public class PathCircle : MonoBehaviour
{
    [Header("Настройки")]
    public int circleNumber = 1;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        // Создаем текст с номером
        CreateNumberText();
    }

    void CreateNumberText()
    {
        GameObject textObj = new GameObject("Number");
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(0, 0, -0.1f);

        TextMesh textMesh = textObj.AddComponent<TextMesh>();
        textMesh.text = circleNumber.ToString();
        textMesh.fontSize = 20;
        textMesh.characterSize = 0.05f;
        textMesh.color = Color.black;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;

        textObj.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
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

    // Метод для установки номера (можно вызывать вручную)
    public void SetNumber(int number)
    {
        circleNumber = number;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = number.ToString();
        }
    }
}