using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusPoint : Point
{
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    [SerializeField] private int _scene;
    public override void PointAction()
    {
        saveLoader.Save(gameData.GetPlayerData());
        SceneManager.LoadScene(_scene);
    }
}
