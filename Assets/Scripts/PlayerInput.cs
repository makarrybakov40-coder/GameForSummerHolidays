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
                _pathPoint = pathPoint;
                StartCoroutine(MoveToPoint());

                if (pathPoint.SpecialPoint == true && pathPoint.SpecialPointMoveTo)
                {
                    StartCoroutine(MoveToSpecialPoint());
                }
            }
        }
    }

    private IEnumerator MoveToPoint() 
    {
        game.ActivePlayer().Move(_pathPoint);
        yield return _pathPoint;
        game.PlayerUnSelect();
    }
    private IEnumerator MoveToSpecialPoint()
    {
        yield return  new WaitForSeconds(2);
        game.PlayerSelect(_playerSelector.PlayerIndex);
        game.ActivePlayer().Move(_pathPoint.SpecialPointMoveTo);
        Debug.Log($"Ход {game.ActivePlayer()} завершен");
        game.PlayerUnSelect();
    }
}
