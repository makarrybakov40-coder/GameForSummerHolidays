using System.Threading.Tasks;
using UnityEngine;

public class MoveToPoint : Point
{
    [SerializeField] private PathPoint pathPoint;
    public override async void PointAction(Game game)
    {
        if (game.ActivePlayer().IsMoving == false)
        {
            game.ActivePlayer().Move(pathPoint);
        }
        else 
        {
            await Task.Delay(100);
            PointAction(game);
        }

    }
}
