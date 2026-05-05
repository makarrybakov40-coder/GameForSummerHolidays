using System.Collections.Generic;
using UnityEngine;


public class PlayerData
{
    public int CurrentPosIndex;
    public int PlayerID;
    public Dictionary<string, int> PlayerFeature;
    public Vector3 Vector;

    public PlayerData(int currentPosIndex, int playerID, Dictionary<string, int> playerFeature, Vector3 vector3)
    {
        CurrentPosIndex = currentPosIndex;
        PlayerID = playerID;
        PlayerFeature = playerFeature;
        Vector = vector3;
    }
}
