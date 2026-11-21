using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RandomSaver", menuName = "Scriptable Objects/RandomSaver")]
public class RandomSaver : ScriptableObject
{
    public int lastPlayerID;
    public List<Player> players;
}
