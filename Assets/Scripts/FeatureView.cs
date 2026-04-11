using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeatureView : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private Image _playerFeatureImage;
    //[SerializeField] private TMP_Text _playerFeatureName;
    [SerializeField] private Button _playerFeautureSelect;
    private Player _player;

    public void PlayerFeatureRender(Player player, int feature)
    {
        _player = player;
        //_playerFeatureImage.sprite = Game.Instance.FeatureSprites[""];

    }
}
