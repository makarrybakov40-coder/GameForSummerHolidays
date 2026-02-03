using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PathConteiner : MonoBehaviour
{
    [SerializeField] private Path _path;
    private Dictionary<int, Path> paths = new Dictionary<int, Path>();

    

    public void SetPathForPlayer(Player player)
    {
         player.SetPath(paths[player.PlayerID]);
    }
}
