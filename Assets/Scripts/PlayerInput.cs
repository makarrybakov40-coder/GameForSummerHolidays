using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            MouseCLickAction(_player);
        }
    }

    private async void MouseCLickAction(Player player)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);        
        
        if (hit.collider == null)
        {
            game.PlayerUnSelect();
            return;
        }

        Debug.Log(hit.transform.name);

        if (hit.collider.TryGetComponent(out PlayerSelector playerSelector))
        {
            game.PlayerSelect(playerSelector.PlayerIndex);           
            return;
        }
        if (hit.collider.TryGetComponent(out PathPoint pathPoint))
        {

            if (game.ActivePlayer() != null)
            {
                game.ActivePlayer().Move(pathPoint);
                await Task.Delay(2000);

                if (pathPoint.SpecialPoint == true && pathPoint.SpecialPointMoveTo)
                {

                    game.ActivePlayer().Move(pathPoint.SpecialPointMoveTo);
                }
            }

            //if (pathPoint.SpecialPoint == true && pathPoint.SpecialPointMoveTo)
            //{
            //    StartCoroutine(MyCoroutine());
            //    game.ActivePlayer().Move(pathPoint.SpecialPointMoveTo);
            //}
         
        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
    }


    //private void SetActivePlayer()
    //{
    //    List<Player> targetGameObject;
    //    targetGameObject = gameObject.transform.GetComponentsInChildren<Player>().ToList();
    //    for (int i = 0; i < targetGameObject.Count; i++)
    //    {
    //        targetGameObject.Add(targetGameObject[i]);
    //    }
    //    for (int i = 0; i < targetGameObject.Count; i++)
    //    {
    //        if (_player.PlayerID == i)
    //        {
    //            targetGameObject[i].gameObject.SetActive(true);
    //        }
    //    }
    //}
}
