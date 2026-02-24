using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private Player _playerIndex;
    public Player PlayerIndex {  get { return _playerIndex; } }
}
