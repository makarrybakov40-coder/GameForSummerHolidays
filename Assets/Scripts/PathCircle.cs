// PathCircle.cs
using UnityEngine;

public class PathCircle : MonoBehaviour
{
<<<<<<< HEAD
    public int circleNumber = 1;
    public int pathIndex = 0;

    private SpriteRenderer sprite;
    private Color normalColor = Color.white;
=======
    [Header("Настройки")]
    public int circleNumber = 1;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        // Разные цвета для разных путей
        if (sprite != null)
        {
<<<<<<< HEAD
            float hue = pathIndex * 0.3f;
            normalColor = Color.HSVToRGB(hue, 0.3f, 1f);
            sprite.color = normalColor;
        }

        // Номер круга
=======
            originalColor = spriteRenderer.color;
        }

        // Создаем текст с номером
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
        CreateNumberText();
    }

    void CreateNumberText()
    {
        GameObject textObj = new GameObject("Number");
        textObj.transform.SetParent(transform);
<<<<<<< HEAD
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
=======
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
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
    {
        if (sprite != null) sprite.color = Color.yellow;
    }

<<<<<<< HEAD
    void OnMouseExit()
    {
        if (sprite != null) sprite.color = normalColor;
=======
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = number.ToString();
        }
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
    }
}