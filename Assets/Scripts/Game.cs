using Project.Tools.DictionaryHelp;
using SaveIsEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game _instance;
    public static Game Instance { get { if (_instance == null) Debug.LogError("instance is NULL"); return _instance; } }

    private List<Player> _allPlayers;
    private Player _activePlayer;    
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
        _instance = this;
        InitializeGame();
        
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
            player.MoveToStartPosition();
            foreach (var item in _playerFeatureDictionary)
            {
                player.PlayerFeature.Add(item.Key, 0);
            }
        }       
        LoadGame();
    }
    private void SaveGame()
    {
        GameData gameData = new GameData();
        SaveLoader saveLoader = new SaveLoader();

        saveLoader.Save(gameData.GetPlayerData());
        for (int i = 0; i < gameData.PlayerData.Count; i++)
        {
            Debug.Log($"Player - {AllPlayers[i]}, PlayerID - {gameData.PlayerData[i].PlayerID}");
            Debug.Log($"Player - {AllPlayers[i]}, CurrentPosIndex - {gameData.PlayerData[i].CurrentPosIndex}");
            Debug.Log($"Player - {AllPlayers[i]}, PlayerFeature - {gameData.PlayerData[i].PlayerFeature[i.ToString()]}");
            Debug.Log($"Player - {AllPlayers[i]}, PlayerFeature - {gameData.PlayerData[i].Vector}");
        }
    }
    private void LoadGame()
    {
        SaveLoader saveLoader = new SaveLoader();
        GameData gameData = new GameData();
        gameData.SetPlayerData();
        saveLoader.Load();
        for (int i = 0; i < gameData.PlayerData.Count; i++)
        {
            //Debug.Log(gameData.PlayerData[i].PlayerID);
            //Debug.Log(gameData.PlayerData[i].PlayerFeature);
            //Debug.Log(gameData.PlayerData[i].CurrentPosIndex);
        }
    }
}
