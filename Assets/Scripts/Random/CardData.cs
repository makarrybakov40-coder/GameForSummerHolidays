using System.Collections.Generic;
using UnityEngine;

public class CardData
{
    public Sprite PlayerSprites;
    public int PlayerID;

    public CardData(int playerID, Sprite playerSprites)
    {
        PlayerID = playerID;
        PlayerSprites = playerSprites;
    }
}
