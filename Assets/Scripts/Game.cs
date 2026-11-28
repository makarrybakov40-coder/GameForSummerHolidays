using Project.Tools.DictionaryHelp;
using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    private static Game _instance;
    public static Game Instance { get { if (_instance == null) Debug.LogError("instance is NULL"); return _instance; } }

    private List<Player> _allPlayers;
    private Player _activePlayer;
    private Player _lastActivePlayer;
    private int _lastActivePlayerID;
    [SerializeField] private PathConteiner _pathConteiner;
    [SerializeField] private SerializableDictionary<string, Sprite> _playerFeatureDictionary;
    public List<Player> AllPlayers { get { return _allPlayers.OrderBy(x => x.PlayerID).ToList(); } }
    public SerializableDictionary<string, Sprite> PlayerFeatureDictionary {  get { return _playerFeatureDictionary; } }

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
        _lastActivePlayer = player;
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

    public int LastActivePlayer()
    {
        _lastActivePlayerID = _lastActivePlayer.PlayerID;
        return _lastActivePlayerID;
    }

    private void Awake()
    {
        //if (_instance != null && _instance != this )
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        _instance = this;
        InitializeGame();
        //DontDestroyOnLoad(gameObject);
        if (DontDestroy.lastPlayerID != -1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                AllPlayers[DontDestroy.lastPlayerID].IncreaseFeatureValue("1", 1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                AllPlayers[DontDestroy.lastPlayerID].IncreaseFeatureValue("0", 1);
            }
        }
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private void InitializeGame()
    {
        _pathConteiner.FindAllPath();
        GetAllPlayers();
        SetPathsToPlayers();
        foreach (Player player in _allPlayers)
        {
            foreach (var item in _playerFeatureDictionary)
            {
                player.PlayerFeature.Add(item.Key, 0);
            }
        }
        LoadGame();
        foreach (Player player in _allPlayers)
        {
            player.MoveToCurrentPosition();
        }
    }
    private void SaveGame()
    {
        saveLoader.Save(gameData.GetPlayerData());
    }
    private void LoadGame()
    {
        var x = saveLoader.Load();
        if (x == null)
        {
            return;
        }
        gameData.SetPlayerData(x);
    }

}
