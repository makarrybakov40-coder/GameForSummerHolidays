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

    //private void Start()
    //{
    //    FindComponentsInChildren(_path[i].PathPoints);
    //}
    //public void FindComponentsInChildren<T>(List<T> targetList) where T : Component
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        Transform child = transform.GetChild(i);
    //        for (int j = 0; j < child.childCount; j++)
    //        {

    //        }
    //        int index = child.GetSiblingIndex();

    //        Debug.Log($"[{i}] {child.name} (SiblingIndex: {index})");
    //    }

    //    targetList.Clear();

    //    T[] childComponents = GetComponentsInChildren<T>();
    //    targetList.AddRange(childComponents);

    //    Debug.Log($"Найдено {targetList.Count} компонентов типа {typeof(T).Name} в потомках");
    //}

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
