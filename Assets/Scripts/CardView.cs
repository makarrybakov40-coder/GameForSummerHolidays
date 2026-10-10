using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private Image _playerFaceImage;
    [SerializeField] private Image _playerBackImage;
    [SerializeField] private Image _playerCardImage;
    private Player _player;
    private int _playerID;

    private void Start()
    {
        _playerFaceImage = GetComponent<Image>();
        _playerFaceImage.sprite = _sprite;
        _playerBackImage = GetComponent<Image>();
        _playerBackImage.sprite = _sprite;
        _playerCardImage = GetComponent<Image>();
        _playerCardImage.sprite = _sprite;
    }
    public void PlayerRender(Player player)
    {
        _player = player;
        _playerFaceImage.sprite = player.Sprite;
    }

}
