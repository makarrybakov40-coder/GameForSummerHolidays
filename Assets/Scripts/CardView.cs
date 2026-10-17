using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private SpriteRenderer _playerFace;
    [SerializeField] private SpriteRenderer _playerBack;
    //[SerializeField] private Sprite _playerCard;
    private Player _player;
    private int _playerID;
    private CardGame _cardGame;

    private void Start()
    {
        _playerFace.sprite = GetComponent<Sprite>();
        _playerFace.sprite = _sprite;
        _playerBack.sprite = GetComponent<Sprite>();
        _playerBack.sprite = _sprite;
       // _playerCard = GetComponent<Sprite>();
       // _playerCard = _sprite;

    }
    public void PlayerRender(Player player)
    {
        _player = player;
        _playerFace.sprite = player.Sprite;
        _playerID = player.PlayerID;
        //_cardGame.ChangeCard(_playerID);
    }

}
