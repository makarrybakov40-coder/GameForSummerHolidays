// PathCircle.cs
using UnityEngine;

public class PathCircle : MonoBehaviour
{
    [Header("Настройки круга")]
    public int circleNumber = 1;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;
    public Color clickColor = Color.green;

    private SpriteRenderer spriteRenderer;
    private bool isMouseOver = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }

        // Добавляем текст с номером
        CreateNumberText();
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }
    }

    void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = clickColor;
        }
    }

    void OnMouseUp()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = isMouseOver ? hoverColor : normalColor;
        }
    }

    void CreateNumberText()
    {
        // Создаем GameObject для текста
        GameObject textObject = new GameObject("CircleNumber");
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = Vector3.zero;

        // Добавляем компонент TextMesh
        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = circleNumber.ToString();
        textMesh.fontSize = 20;
        textMesh.characterSize = 0.1f;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.color = Color.black;

        // Настройка размера
        textObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    }

    // Метод для установки номера
    public void SetCircleNumber(int number)
    {
        circleNumber = number;

        // Обновляем текст
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = number.ToString();
        }
    }
}