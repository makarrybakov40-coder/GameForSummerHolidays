using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> CardFace;
    [SerializeField] private List<GameObject> CardBack;
    private int CardWinnerID;

    private void Start()
    {
        CardWinnerID = Game.Instance.LastActivePlayer();
        ChangeSpriteToSmile();
    }
    public void ChangeSpriteToSmile()
    {
        for (int i = 0; i < CardFace.Count; i++)
        {
            CardFace[i].SetActive(true);
            CardBack[i].SetActive(false);
        }
    }
    public void ChangeSpriteToOriginal()
    {
        for (int i = 0; i < CardFace.Count; i++)
        {
            CardFace[i].SetActive(false);
            CardBack[i].SetActive(true);
        }
    }

}
