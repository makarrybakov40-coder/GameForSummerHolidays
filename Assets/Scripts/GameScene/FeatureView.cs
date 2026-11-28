using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeatureView : MonoBehaviour
{
    [SerializeField] private Image _playerFeatureImage;
    [SerializeField] private TMP_Text _playerFeatureText;
    private Player _player;
    private string _featureKey;
    [SerializeField] int _featureIncreaseValue;

    public void IncreaseFeature()
    {
        _player.IncreaseFeatureValue(_featureKey, _featureIncreaseValue);
        UpdateFeatureValueText();
    }
    public void DecreaseFeature()
    {
        _player.DecreaseFeatureValue(_featureKey, _featureIncreaseValue);
        UpdateFeatureValueText();
    }
    public void PlayerFeatureRender(Player player, string featureKey)
    {
        _player = player;
        _featureKey = featureKey;
        _playerFeatureImage.sprite = Game.Instance.PlayerFeatureDictionary[featureKey];
        UpdateFeatureValueText();
    }

    public void UpdateFeatureValueText()
    {
        _playerFeatureText.text = _player.PlayerFeature[_featureKey].ToString();
    }
}



