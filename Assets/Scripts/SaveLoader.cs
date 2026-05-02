using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


public class SaveLoader
{
    private string GAMEID = "GAME1";
    public void Save(List<PlayerData> playerDatas)
    {  
      string data = JsonUtility.ToJson(playerDatas);

      PlayerPrefs.SetString(GAMEID, data);
    }

   
    public List<PlayerData> Load()
    {
        if (PlayerPrefs.HasKey(GAMEID))
        {
            string data = PlayerPrefs.GetString(GAMEID);
            return JsonUtility.FromJson<List<PlayerData>>(data);
        } 

        return null;   
    }
}