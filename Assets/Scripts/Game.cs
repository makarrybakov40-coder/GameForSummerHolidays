using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    private List<Player> _allPlayers;
    private Player _activePlayer;
    [SerializeField] private PathConteiner _pathConteiner;

    public void SetPathsToPlayers()
    {
        foreach (Player player in _allPlayers)
        {
            _pathConteiner.SetPathForPlayer(player);
        }
    }

    public void GetAllPlayers()
    {
        _allPlayers = FindObjectsByType<Player>(FindObjectsSortMode.None).ToList();
    }

    public void PlayerSelect(Player player)
    {
        PlayerUnSelect();
        _activePlayer = player;
        _activePlayer.EnableOutLine();
    }

    public void PlayerUnSelect()
    {
        if (_activePlayer != null)
        {
            _activePlayer.DisableOutLine();
        }

        _activePlayer = null;
    }

    public Player ActivePlayer()
    {
        return _activePlayer;
    }

    private void Awake()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        _pathConteiner.FindAllPath();
        GetAllPlayers();
        SetPathsToPlayers();

        foreach (Player player in _allPlayers)
        {
            player.MoveToStartPosition();
        }

    }
}
