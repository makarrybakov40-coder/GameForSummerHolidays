using UnityEngine;

public class CardInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseCLickAction();
        }
        if (Input.GetMouseButtonDown(1))
        {
            MouseCLickAction1();
        }
    }

    private void MouseCLickAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider == null)
        {
            return;
        }
        if (hit.collider.TryGetComponent(out ChangeSprite changeSprite)) 
        {
            changeSprite.ChangeSpriteToOriginal();
        }


    }
    private void MouseCLickAction1()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider == null)
        {
            return;
        }
        if (hit.collider.TryGetComponent(out ChangeSprite changeSprite))
        {
            changeSprite.ChangeSpriteToSmile();
        }


    }
}
