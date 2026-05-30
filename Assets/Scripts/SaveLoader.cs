using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class SaveLoader
{
    private string GAMEID = "GAME1";
    public void Save(List<PlayerData> playerDatas)
    {
        string data = JsonConvert.SerializeObject(playerDatas);

        PlayerPrefs.SetString(GAMEID, data);
    }

   
    public List<PlayerData> Load()
    {
        if (PlayerPrefs.HasKey(GAMEID))
        {
            GameData gameData = new GameData();
            //gameData.SetPlayerData();
            string data = PlayerPrefs.GetString(GAMEID);
            return JsonConvert.DeserializeObject<List<PlayerData>>(data);
        }            
        return null;   
    }

    public void DeleteSaveFile() 
    {
        PlayerPrefs.DeleteAll();
    }
}