using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Game game;

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

        if (hit.collider.TryGetComponent(out Player player))
        {
            game.PlayerSelect(player);
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
}
