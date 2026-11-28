using UnityEngine;
using System.Collections.Generic;
public class ChangeAllCards : MonoBehaviour
{
    [SerializeField] private List<Sprite> _backSprites;
    private List<Sprite> _faceSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < DontDestroy.cards.Count; i++)
        {
           SetSprites(i ,DontDestroy.cards[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetSprites(int ID,CardData cardData)
    {
        _faceSprites[ID] = cardData.PlayerSprites;
    }
}
