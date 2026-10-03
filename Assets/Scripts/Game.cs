using Project.Tools.DictionaryHelp;
using SaveIsEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    private static Game _instance;
    public static Game Instance { get { if (_instance == null) Debug.LogError("instance is NULL"); return _instance; } }

    private List<Player> _allPlayers;
    private Player _activePlayer;
    private Player _lastActivePlayer;
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

    public Player LastActivePlayer()
    {
        return _lastActivePlayer;
    }

    private void Awake()
    {
        Debug.Log(gameObject.name);
        //if (_instance != null) 
        //{
        //    Destroy(gameObject);
        //    return;
        //}     
        _instance = this;
        InitializeGame();
        //DontDestroyOnLoad(gameObject);
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
