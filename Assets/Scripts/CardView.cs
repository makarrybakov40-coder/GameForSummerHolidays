using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private Sprite _playerFace;
    [SerializeField] private SpriteRenderer _playerFaceRender;
    private Player _player;
    private int _playerID;
    private CardGame _cardGame;


    private void Start()
    {

        _playerFaceRender = GetComponent<SpriteRenderer>();
        _playerFaceRender.sprite = _sprite;

    }
    public void CardRender(Player player)
    {
        _player = player;
        _playerFace = player.Sprite;
        _playerID = player.PlayerID;
        _playerFaceRender.sprite = _playerFace;
    }

}
