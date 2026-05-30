using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private GameObject CardFace;
    [SerializeField] private GameObject CardBack;

    private void Start()
    {
        //CardBack = Game.Instance.LastActivePlayer().gameObject;
        ChangeSpriteToSmile();
    }
    public void ChangeSpriteToSmile()
    {
        CardFace.SetActive(true);
        CardBack.SetActive(false);
    }
    public void ChangeSpriteToOriginal()
    {
        CardFace.SetActive(false);
        CardBack.SetActive(true);
    }

}
