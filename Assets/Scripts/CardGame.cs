using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{
    private List<Card> _cards;
    private int _cardWinnerID;

    private void Start()
    {
        _cardWinnerID = DontDestroy.lastPlayerID;
    }
    public void ChangeCard(int index)
    {
       //_cards.Add()
    }

}
