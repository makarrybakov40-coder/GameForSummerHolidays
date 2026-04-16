using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Playerview : MonoBehaviour
{
    private Sprite _sprite;
    [SerializeField] private Image _playerImage;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private Button _playerSelect;
    [SerializeField] private FeatureView _feature;
    [SerializeField] private GameObject _playerFeatureConteiner;
    private int _featureCount;
    private Player _player;

    private void Start()
    {
        _playerImage = GetComponent<Image>();       
        _playerImage.sprite = _sprite;
    }
    public void PlayerRender(Player player)
    {
        _player = player;
        _playerImage.sprite = player.Sprite;
        _playerName.text = player.PlayerName;
        var buttonChild = GetComponentInChildren<PlayerSelector>();
        buttonChild.PlayerIndex = player;
        _featureCount = Game.Instance.PlayerFeatureDictionary.Count;

        for (int i = 0; i < _featureCount; i++) 
        {
            AddPlayerFeature(player, i);
        }
        
    }
    public void AddPlayerFeature(Player player, int featureID)
    {
        var view = Instantiate(_feature, _playerFeatureConteiner.transform);
        view.PlayerFeatureRender(player, featureID);
    }

}
