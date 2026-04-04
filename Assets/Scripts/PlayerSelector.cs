using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    private Player _playerIndex;
    public Player PlayerIndex { get { return _playerIndex; } set { _playerIndex = value; } }

    public void OnClickButton() 
    {
        Game.Instance.PlayerSelect(PlayerIndex);
    }
}
