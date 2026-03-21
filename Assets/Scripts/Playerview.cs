using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Playerview : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private Image _playerImage;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private Button _playerSelect;
    private Player _player;

    private void Start()
    {
        _playerImage = GetComponent<Image>();       
        _playerImage.sprite = _sprite;
    }
    public void Render(Player player)
    {
        _player = player;
        _playerImage.sprite = player.Sprite;
        _playerName.text = player.PlayerName;
        
    }

}
