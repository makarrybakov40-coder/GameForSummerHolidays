using System.Collections.Generic;
using UnityEngine;

public class GenerateObjectsAtStart : MonoBehaviour
{
    //[SerializeField] private List<Player> _generatePlayers;
    [SerializeField] private GameObject _playerConteiner;
    [SerializeField] private Playerview _playerView;
    [SerializeField] private CardView _cardView;

    private void Start()
    {
        for (int i = 0;  i < Game.Instance.AllPlayers.Count; i++)
        {
            if (_playerView != null && _cardView == null)
            {
                AddPlayerPlayerView(Game.Instance.AllPlayers[i]);

            }
            else if (_cardView != null && _playerView == null)
            {
                AddPlayerCardView(Game.Instance.AllPlayers[i]);
            }
        } 
    }

    private void AddPlayerPlayerView(Player player)
    {
        var view = Instantiate(_playerView, _playerConteiner.transform);
        view.PlayerRender(player);
    }
    private void AddPlayerCardView(Player player)
    {
        var view = Instantiate(_cardView, _playerConteiner.transform);
        view.PlayerRender(player);
    }
}
