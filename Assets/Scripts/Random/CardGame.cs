using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{
    [SerializeField] private TestChangeSprite test;
    private int _cardWinnerID;

    private void Awake()
    {
        //_cardWinnerID = DontDestroy.lastPlayerID;
    }

}
