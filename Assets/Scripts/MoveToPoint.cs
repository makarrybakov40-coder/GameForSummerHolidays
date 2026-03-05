using System.Threading.Tasks;
using UnityEngine;

public class MoveToPoint : Point
{
    public PathPoint pathPoint;
    public override void PointAction(Game game)
    {
        game.ActivePlayer().Move(pathPoint);
    }


}
