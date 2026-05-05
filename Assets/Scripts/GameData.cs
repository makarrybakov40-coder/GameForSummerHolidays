using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
public class GameData
{
    private List<PlayerData> _playerData = new List<PlayerData>();
    public List<PlayerData> PlayerData { get { return _playerData; } }
    public List<PlayerData> GetPlayerData()
    {
        List<Player> players = Game.Instance.AllPlayers;
        for (int i = 0; i < Game.Instance.AllPlayers.Count; i++)
        {
            PlayerData playerdata = new PlayerData(players[i].CurrentPositionIndex, players[i].PlayerID, players[i].PlayerFeature, players[i].transform.position);
           _playerData.Add(playerdata);
        }

        return _playerData;
    }
    public void SetPlayerData()
    {
        GetPlayerData();
        List<Player> players = Game.Instance.AllPlayers;
        for (int i = 0; i < _playerData.Count; i++)
        {
            players[i].SetPlayerData(this);
        }

    }
}
