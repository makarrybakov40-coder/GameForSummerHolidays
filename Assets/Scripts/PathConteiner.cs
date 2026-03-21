using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PathConteiner : MonoBehaviour
{
    //[SerializeField] private int i;
    private Dictionary<int, Path> _paths = new Dictionary<int, Path>();

    private bool _isSingleWay = false;

    public void FindAllPath()
    {
        List<Path> paths = new List<Path>();
        paths = gameObject.transform.GetComponentsInChildren<Path>().ToList();
        if (paths.Count == 1 )
        {
            _isSingleWay = true;
            paths.First().SetSingleWay();
        }
        _paths = paths.ToDictionary(p => p.PlayerID);
        foreach (var path in _paths) 
        {
            path.Value.FindAllPathPoints();
        }

    }


    public void SetPathForPlayer(Player player)
    {
        if (!_isSingleWay)
        {
            player.SetPath(_paths[player.PlayerID]);
        }
        else
        {
            player.SetPath(_paths.First().Value);
        }

    }
}
