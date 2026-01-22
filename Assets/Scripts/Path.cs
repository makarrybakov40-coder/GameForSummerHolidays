using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Path
{
    [SerializeField] private int _playerID;
    [SerializeField] private int _pathID;
    [SerializeField] private string _searchTag = "PathPoint";

    public  List<PathPoint> PathPoints;

    public int PlayerID { get { return _playerID; } }
    public int PathID { get { return _pathID; } }

    public List<PathPoint> foundPoint = new List<PathPoint>();

    public Path(int pathID, int playerID)
    {
        _pathID = pathID;
        _playerID = playerID;
    }

    void FindByTag(string tag)
    {
        foundPoint.Clear();

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in taggedObjects)
        {
            PathPoint pathPoints = obj.GetComponent<PathPoint>();
            if (pathPoints != null)
            {
                foundPoint.Add(pathPoints);
            }
        }
    }
}