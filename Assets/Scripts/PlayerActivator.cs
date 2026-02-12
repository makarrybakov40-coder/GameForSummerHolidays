using System.Collections.Generic;
using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    [SerializeField] private List<GameObject> PlayerActivatore;

    private void Update()
    {
        SetPlayerObjectActive();
    }
    private void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("PlayerSelector");
        for (int i = 0; i < foundObjects.Length; i++)
        {
            PlayerActivatore[i].SetActive(false);
        }
    }

    private void SetPlayerObjectActive()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider.TryGetComponent(out Player player))
            {
                Debug.Log("if");
                PlayerActivatore[player.PlayerID].SetActive(true);
            }
            //else if (hit.collider == BoxCollider2D)
            //{
            //    Debug.Log("else");
            //    for (int i = 0; i < PlayerActivatore.Count; i++)
            //    {
            //        PlayerActivatore[i].SetActive(false);
            //    }
            //}

        }
    }
}
