using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

public class BonusPoint : Point
{
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    [SerializeField] private int _scene;
    public override void PointAction()
    {
        StartCoroutine(Delayer());
    }
    private IEnumerator Delayer()
    {

        yield return new WaitForSeconds(2);
        saveLoader.Save(gameData.GetPlayerData());
        SceneManager.LoadScene(_scene);
    }
}
