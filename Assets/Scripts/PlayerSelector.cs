using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    private Player _playerIndex;
    public Player PlayerIndex { get { return _playerIndex; } set { _playerIndex = value; } }
    public int SceneIndex;
    public void OnClickButton() 
    {
        Game.Instance.PlayerSelect(PlayerIndex);
    }
    public void NextScene()
    {
        saveLoader.Save(gameData.GetPlayerData());
        SceneManager.LoadScene(SceneIndex);
    }
}
