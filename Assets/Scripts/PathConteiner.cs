using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathConteiner : MonoBehaviour
{
    [SerializeField] private Dictionary<int, Path> paths = new Dictionary<int, Path>();


    private void Start()
    {
        CreatePlayerPaths();
    }
    public void CreatePlayerPaths()
    {
        // Находит все активные объекты с компонентом
        PathPoint[] allComponents = FindObjectsByType<PathPoint>(FindObjectsSortMode.None);
        foreach (PathPoint comp in allComponents)
        {
           if (paths.ContainsKey(comp.PlayerID))
           {
                paths[comp.PlayerID].AddPathPoint(comp);
           }
           else
           {
                paths.Add(comp.PlayerID, new Path(comp.PlayerID));
                paths[comp.PlayerID].AddPathPoint(comp);
           }
        }

        foreach (KeyValuePair<int, Path> item in paths)
        {
            item.Value.SortPathPoints();
        }

        foreach (KeyValuePair<int, Path> item in paths)
        {
            foreach (PathPoint item1 in item.Value.PathPoints)
            {
                Debug.Log(item1.name);
            }
        }

        Debug.Log(paths.Count);
    }
    public Path GetPathForPlayer(int playerID)
    {
        return paths.Where(x => x.Key == playerID).Select(x => x.Value).FirstOrDefault();
    }


}
