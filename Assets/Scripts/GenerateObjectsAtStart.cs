using System.Collections.Generic;
using UnityEngine;

public class GenerateObjectsAtStart : MonoBehaviour
{
    //[SerializeField] private List<Player> _generatePlayers;
    [SerializeField] private GameObject _playerConteiner;
    [SerializeField] private Playerview _playerView;
    [SerializeField] private int _playerPointCount;
    [SerializeField] private bool _isPlayerView;

    private void Start()
    {
            for (int i = 0;  i < Game.Instance.AllPlayers.Count; i++)
            {
                AddPlayer(Game.Instance.AllPlayers[i]);
            }   
            for (int i = 0; i < _playerPointCount; i++)
            {
                AddPlayer(Game.Instance.AllPlayers[i]);
            }
    }

    private void AddPlayer(Player player)
    {
        var view = Instantiate(_playerView, _playerConteiner.transform);
        view.Render(player);
    }
}
