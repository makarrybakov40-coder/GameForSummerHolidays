using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    private Player _playerIndex;
    public Player PlayerIndex { get { return _playerIndex; } set { _playerIndex = value; } }
    public int SceneIndex;
    public void OnClickButton() 
    {
        Game.Instance.PlayerSelect(PlayerIndex);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
