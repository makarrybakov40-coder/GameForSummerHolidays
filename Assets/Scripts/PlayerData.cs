using System.Collections.Generic;
using UnityEngine;


public class PlayerData
{
    public int CurrentPosIndex;
    public int PlayerID;
    public Dictionary<string, int> PlayerFeature;

    public PlayerData(int currentPosIndex, int playerID, Dictionary<string, int> playerFeature)
    {
        CurrentPosIndex = currentPosIndex;
        PlayerID = playerID;
        PlayerFeature = playerFeature;
    }
}
