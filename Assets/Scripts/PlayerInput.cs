using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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
            Game.Instance.PlayerUnSelect();
            return;
        }

        if (hit.collider.TryGetComponent(out PlayerSelector playerSelector))
        {
            _playerSelector = playerSelector;
            Game.Instance.PlayerSelect(playerSelector.PlayerIndex);           
        }
        if (hit.collider.TryGetComponent(out Point pathPoint))
        {
            
            if (Game.Instance.ActivePlayer() != null)
            {
                Game.Instance.ActivePlayer().Move(pathPoint);
            }
        }
    }
}
