using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
public class GameData
{
    private List<PlayerData> _playerData = new List<PlayerData>();
    public List<PlayerData> PlayerData { get { return _playerData.OrderBy(x => x.PlayerID).ToList(); } }

    public List<PlayerData> GetPlayerData()
    {
        List<Player> players = Game.Instance.AllPlayers;
        for (int i = 0; i < Game.Instance.AllPlayers.Count; i++)
        {
            PlayerData playerdata = new PlayerData(players[i].CurrentPositionIndex, players[i].PlayerID, players[i].PlayerFeature);
           _playerData.Add(playerdata);
        }

        return _playerData;
    }
    public void SetPlayerData(List<PlayerData> x)
    {
        //GetPlayerData();
        List<Player> players = Game.Instance.AllPlayers;
        for (int i = 0; i < players.Count; i++)
        {
            players[i].SetPlayerData(x[i]);
        }

    }
}
