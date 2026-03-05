using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Game game;
    private PathPoint _pathPoint;
    private PlayerSelector _playerSelector;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseCLickAction();
        }
    }

    private void MouseCLickAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);        
        
        if (hit.collider == null)
        {
            game.PlayerUnSelect();
            return;
        }

        if (hit.collider.TryGetComponent(out PlayerSelector playerSelector))
        {
            _playerSelector = playerSelector;
            game.PlayerSelect(playerSelector.PlayerIndex);           
        }
        if (hit.collider.TryGetComponent(out PathPoint pathPoint))
        {

            if (game.ActivePlayer() != null)
            {
                //game.ActivePlayer().Move(pathPoint);
                if (hit.collider.TryGetComponent(out MoveToPoint moveToPoint) && moveToPoint.isActiveAndEnabled) 
                {
                    game.ActivePlayer().Move(pathPoint);
                    moveToPoint.PointAction(game);
                }
                else
                {
                    game.ActivePlayer().Move(pathPoint);
                }
                //if (game.ActivePlayer().IsMoving == false) 
                //{
                //    pathPoint.PointAction(game);
                //}

            }
        }
    }
}
