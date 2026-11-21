using System.Collections.Generic;
using UnityEngine;

public class TestChangeSprite : MonoBehaviour
{
    private Sprite CurCardSprite;
    private Sprite _cardFace;
    [SerializeField] private SpriteRenderer CardRenderer;
    [SerializeField] private Sprite CardBack;
    public Sprite CardFace { get { return _cardFace; } set { _cardFace = value; } }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeValue(Sprite value)
    {
        _cardFace = value;
        CardRenderer.sprite = _cardFace;
    }


    public void ChangeSpriteToSmile()
    {
        CurCardSprite = CardBack;
        CardRenderer.sprite = CurCardSprite;

    }
    public void ChangeSpriteToOriginal()
    {
        CurCardSprite = _cardFace;
        CardRenderer.sprite = CurCardSprite;
    }
}
