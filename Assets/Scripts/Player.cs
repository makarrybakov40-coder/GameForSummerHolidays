using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;
[RequireComponent(typeof(PlayerMovement))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _playerID = 0;
    [SerializeField] private Material _outlineMaterial;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _playerName;


    private Path _playerPath;
    private PlayerMovement playerMovement;
    private Material _defaultMaterial;
    private int currentPositionIndex = 0;
    private SpriteRenderer _spriteRenderer;
    private bool _isMoving = false;
    private Dictionary<string, int> _playerFeature = new Dictionary<string, int>();
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public Sprite Sprite { get { return _sprite; } }
    public string PlayerName { get { return _playerName; } }
    public int PlayerID { get { return _playerID; } }
    public bool IsMoving { get { return _isMoving; } }
    public Dictionary<string, int> PlayerFeature { get { return _playerFeature; } }

    public void IncreaseFeatureValue(string featureKey, int value)
    {
        PlayerFeature[featureKey] += value;
        Debug.Log($"Player {this.name} Feature {featureKey} - {_playerFeature[featureKey]}");
    }
    public void DecreaseFeatureValue(string featureKey, int value)
    {
        PlayerFeature[featureKey] -= value;
        Debug.Log($"Player {this.name} Feature {featureKey} - {_playerFeature[featureKey]}");
    }
    public void SetPath(Path path)
    {
        _playerPath = path;        
    }

    public void Move(Point pathPoint)
    {
        if (pathPoint.PlayerID == PlayerID || pathPoint.PlayerID == -1 && playerMovement.IsMoving == false) 
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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;       
    }

    public void EnableOutLine()
    {
        _spriteRenderer.material = _outlineMaterial;
    }
    public void DisableOutLine()
    {
        _spriteRenderer.material = _defaultMaterial;
    }

    private void Update()
    {
        _isMoving = playerMovement.IsMoving;
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
