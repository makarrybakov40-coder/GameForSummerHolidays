using System.Collections.Generic;
using UnityEngine;

public class GenerateObjectsAtStart : MonoBehaviour
{
    [SerializeField] private List<PlayerSelector> _generatePlayers;
    [SerializeField] private GameObject _playerConteiner;
    [SerializeField] private List<Playerview> _playerview;

    private void Start()
    {
        for (int i = 0;  i < _generatePlayers.Count; i++)
        {
            AddPlayer(_generatePlayers[i]);
        }   
    }

    private void AddPlayer(PlayerSelector playerSelector)
    {
        for (int i = 0; i < _playerview.Count; i++) 
        {
            var views = Instantiate(_playerview[i], _playerConteiner.transform);
        
            views.Render(playerSelector);
        }
        
    }
}
