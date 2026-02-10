using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Game game;
    private Player _player;

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
            game.PLayerUnSelect();
            return;
        }

        Debug.Log(hit.transform.name);

        if (hit.collider.TryGetComponent(out Player player))
        {
            game.PlayerSelect(player);
            SetActivePlayer();
            return;
        }
        if (hit.collider.TryGetComponent(out PathPoint pathPoint))
        {

            if (game.ActivePlayer() != null)
            {
                game.ActivePlayer().Move(pathPoint);
            }
         
        }
    }

    private void SetActivePlayer()
    {
        List<Player> targetGameObject;
        targetGameObject = gameObject.transform.GetComponentsInChildren<Player>().ToList();
        for (int i = 0; i < targetGameObject.Count; i++)
        {
            targetGameObject.Add(targetGameObject[i]);
        }
        for (int i = 0; i < targetGameObject.Count; i++)
        {
            if (_player.PlayerID == i)
            {
                targetGameObject[i].gameObject.SetActive(true);
            }
        }
    }
}
