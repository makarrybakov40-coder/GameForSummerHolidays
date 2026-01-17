using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(PlayerMovement))]

public class Player : MonoBehaviour
{
        
    [SerializeField] private Path _playerPath;
    [SerializeField] private PlayerMovement playerMovement;

    private int _playerID;
    private int currentPositionIndex = 0;

    public int PlayerID { get { return _playerID; } }

    public void SetPath(Path path)
    {
        _playerPath = path;
        if (_playerPath.PathPoints.Count > 0)
        {
            currentPositionIndex = 0;
            transform.position = _playerPath.PathPoints[0].transform.position;
        }
    }

    public void Move(PathPoint pathPoint)
    {
        playerMovement.MoveToPathPoint(_playerPath, pathPoint);
    }

    private void Start()
    {

        if (_playerPath.PathPoints.Count > 0)
        {
            // Ставим на первый круг
            transform.position = _playerPath.PathPoints[0].transform.position;
            currentPositionIndex = 0;
        }
 
        playerMovement = GetComponent<PlayerMovement>();
    }    
    



    //void OnDrawGizmos()
    //{
    //    if (_playerPath.PathPoints.Count < 2) return;

    //    Gizmos.color = playerColor;

    //    // Рисуем линию пути
    //    for (int i = 0; i < _playerPath.PathPoints.Count - 1; i++)
    //    {
    //        if (_playerPath.PathPoints[i] != null && _playerPath.PathPoints[i + 1] != null)
    //        {
    //            Gizmos.DrawLine(_playerPath.PathPoints[i].transform.position, _playerPath.PathPoints[i + 1].transform.position);
    //        }
    //    }

    //    // Показываем текущую позицию
    //    if (currentPositionIndex < _playerPath.PathPoints.Count && _playerPath.PathPoints[currentPositionIndex] != null)
    //    {
    //        Gizmos.color = Color.white;
    //        Gizmos.DrawWireSphere(_playerPath.PathPoints[currentPositionIndex].transform.position, 0.2f);
    //    }
    //}
}
