using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    public void ChangeScene(int SceneIndex)
    {
        var curScene = SceneManager.GetActiveScene();
        if (curScene.buildIndex == 0)
        {
            DontDestroy.lastPlayerID = Game.Instance.LastActivePlayer();
            DontDestroy.players = Game.Instance.AllPlayers;
            saveLoader.Save(gameData.GetPlayerData());
        }
        SceneManager.LoadScene(SceneIndex);
        
      
    }
}