// PathCircle.cs
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField] private int _pathID;

    [Header("Настройки")]
    private Color normalColor = Color.white;
    private Color hoverColor = Color.yellow;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public int PathID {  get { return _pathID; } }

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

    // Метод для установки номера (можно вызывать вручную)
    public void SetNumber(int number)
    {

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = number.ToString();
        }
    }
}