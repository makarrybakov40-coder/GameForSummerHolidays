using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Path
{
    [SerializeField] private int _playerID;
    [SerializeField] private int _pathID;

    public  List<PathPoint> PathPoints;

    public int PlayerID { get { return _playerID; } }
    public int PathID { get { return _pathID; } }

    public Path(int pathID, int playerID)
    {
        _pathID = pathID;
        _playerID = playerID;
    }
}