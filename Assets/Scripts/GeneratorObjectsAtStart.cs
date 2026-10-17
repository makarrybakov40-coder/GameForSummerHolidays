using System.Collections.Generic;
using UnityEngine;

public class GeneratorObjectsAtStart : MonoBehaviour
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
                AddPlayerView(Game.Instance.AllPlayers[i]);

            }
            else if (_cardView != null && _playerView == null)
            {
                AddCardView(DontDestroy.players[i]);
            }
        } 
    }

    private void AddPlayerView(Player player)
    {
        var view = Instantiate(_playerView, _playerConteiner.transform);
        view.PlayerRender(player);
    }
    private void AddCardView(Player player)
    {
        var view = Instantiate(_cardView, _playerConteiner.transform);
        view.PlayerRender(player);
    }
}
