using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Path : MonoBehaviour
{
    [SerializeField] private int _playerID;

    private  List<PathPoint> _pathPoints;

    public  List<PathPoint> PathPoints {  get { return _pathPoints; } }
    public int PlayerID { get { return _playerID; } }

    public void AddPathPoint(PathPoint pathPoint)
    {
        _pathPoints.Add(pathPoint);
    }

    public void SortPathPoints()
    {
        var filteredPathPoint = _pathPoints.OrderBy(p => p.PositionNumber);
        _pathPoints = filteredPathPoint.ToList();
    }

    private void GetAllPathPoints()
    {
        _pathPoints = gameObject.transform.GetComponentsInChildren<PathPoint>().ToList();
        
        for (int i = 0; i < _pathPoints.Count; i++)
        {
            _pathPoints[i].ConnectPointToPath(this);
        }

    }

    private void Start()
    {
        GetAllPathPoints();
    }
}