using UnityEngine;
using UnityEngine.UI;

public class Playerview : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private Image _spriteImage;

    private void Start()
    {
        _spriteImage = GetComponent<Image>();
        _spriteImage.sprite = _sprite;
    }
    public void Render(Player player)
    {

    }
}
