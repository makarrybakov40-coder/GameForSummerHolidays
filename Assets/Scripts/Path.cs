using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class Path
{
    [SerializeField] private int _playerID;

    private  List<PathPoint> _pathPoints;

    public  List<PathPoint> PathPoints {  get { return _pathPoints; } }
    public int PlayerID { get { return _playerID; } }

    public Path(int playerID)
    {
        _playerID = playerID;
        _pathPoints = new List<PathPoint>();
    }

    public void AddPathPoint(PathPoint pathPoint)
    {
       _pathPoints.Add(pathPoint);
    }

    public void SortPathPoints()
    {
        var filteredPathPoint = _pathPoints.OrderBy(p => p.PositionNumber);
        _pathPoints = filteredPathPoint.ToList();
        Debug.Log(_pathPoints);
    }
}