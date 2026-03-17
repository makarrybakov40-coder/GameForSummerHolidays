using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private Player _playerIndex;
    [SerializeField] private Sprite _sprite;
    public  Sprite Sprite { get { return _sprite; } }
    public Player PlayerIndex {  get { return _playerIndex; } }

    public void OnClickButton() 
    {
        Game.Instance.PlayerSelect(PlayerIndex);
    }
}
