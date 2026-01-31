using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathConteiner : MonoBehaviour
{
    private Dictionary<int, Path> paths = new Dictionary<int, Path>();


    public void SetPathForPlayer(Player player)
    {
         player.SetPath(paths[player.PlayerID]);
    }
}
