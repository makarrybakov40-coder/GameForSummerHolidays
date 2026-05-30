using System.Collections;
using System.Threading.Tasks;
using UnityEngine;


public class MoveToPoint : Point
{
    public PathPoint pathPoint;
    [SerializeField] private float _delay;
    GameData gameData = new GameData();
    SaveLoader saveLoader = new SaveLoader();
    public override void PointAction()
    {
        StartCoroutine(Delayer());
    }

    private IEnumerator Delayer() 
    {
        
        yield return new WaitForSeconds(_delay);
        Game.Instance.ActivePlayer().Move(pathPoint);
        saveLoader.Save(gameData.GetPlayerData());
    }


}
