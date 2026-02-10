using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(PlayerMovement))]

public class Player : MonoBehaviour
{
    private Path _playerPath;
    private PlayerMovement playerMovement;

    [SerializeField] private int _playerID = 0;
    [SerializeField] private GameObject PlayerActivator;
    private int currentPositionIndex = 0;

    public int PlayerID { get { return _playerID; } }


    public void SetPath(Path path)
    {
        _playerPath = path;
    }

    public void Move(PathPoint pathPoint)
    {
        if (pathPoint.PlayerID == PlayerID || pathPoint.PlayerID == -1) 
        {
            playerMovement.MoveToPathPoint(_playerPath, pathPoint, currentPositionIndex);
            currentPositionIndex = pathPoint.PositionNumber;
        }
    }

    public void MoveToStartPosition()
    {
        if (_playerPath.PathPoints.Count > 0)
        {
            // Ставим на первый круг
            transform.position = _playerPath.PathPoints[0].transform.position;
            currentPositionIndex = 0;
        }

    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider.TryGetComponent(out Player player))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (PlayerID == i)
                    {
                        PlayerActivator.SetActive(true);
                    }
                }

            }
            else if (hit.collider == null)
            {
                PlayerActivator.SetActive(false);
            }

        }
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
