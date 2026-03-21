using System.Collections.Generic;
using UnityEngine;

public class GenerateObjectsAtStart : MonoBehaviour
{
    //[SerializeField] private List<Player> _generatePlayers;
    [SerializeField] private GameObject _playerConteiner;
    [SerializeField] private Playerview _playerview;

    private void Start()
    {
        for (int i = 0;  i < Game.Instance.AllPlayers.Count; i++)
        {
            AddPlayer(Game.Instance.AllPlayers[i]);
        }   
    }

    private void AddPlayer(Player player)
    {
        var view = Instantiate(_playerview, _playerConteiner.transform);
        view.Render(player);
    }
}
