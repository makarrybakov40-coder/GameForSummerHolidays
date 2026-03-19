using UnityEngine;
using UnityEngine.UI;

public class Playerview : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private Image _spriteImage;
    PlayerSelector _playerSelector;

    private void Start()
    {
        _spriteImage = GetComponent<Image>();
        _spriteImage.sprite = _sprite;
    }
    public void Render(PlayerSelector playerSelector)
    {
        _playerSelector = playerSelector;

    }
}
