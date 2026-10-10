using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    private Player _playerIndex;
    public Player PlayerIndex { get { return _playerIndex; } set { _playerIndex = value; } }
    public int SceneIndex;
    public void OnClickButton() 
    {
        Game.Instance.PlayerSelect(PlayerIndex);
    }
    public void NextScene()
    {
        _sceneChanger.ChangeScene(SceneIndex);
    }
}
