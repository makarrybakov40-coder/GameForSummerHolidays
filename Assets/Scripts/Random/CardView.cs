using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private Sprite _playerFace;
    [SerializeField] private SpriteRenderer _playerFaceRender;
    public Sprite PlayerFace { get { return _playerFace; } }
    private Player _player;
    private int _playerID;
    private TestChangeSprite test;


    private void Start()
    {


    }
    public void CardRender(Player player)
    {
        test = GetComponentInChildren<TestChangeSprite>();
        //_playerFaceRender = GetComponent<SpriteRenderer>();
        //_playerFaceRender.sprite = _sprite;
        _player = player;
        _playerFace = player.Sprite;
        _playerID = player.PlayerID;
        test.ChangeValue(_playerFace);
    }

}
