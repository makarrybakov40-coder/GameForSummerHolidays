using UnityEngine;
using System.Collections.Generic;

public class ParentCardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cardConteiner;
    [SerializeField] private CardView _cardView;
    private List<Vector3> _cardSpawn = new List<Vector3>();
    void Start()
    {
        Camera cam = Camera.main;
        Vector3 worldPosition = Camera.main.transform.position;
        Vector3 centerPos = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Vector3 plusPos = new Vector3(cam.orthographicSize * 2 * cam.aspect / DontDestroy.players.Count, 0f , 0f);
        Vector3 tempworldPos = Camera.main.ScreenToWorldPoint(centerPos);

        Vector3 worldPos = new Vector3(tempworldPos.x, tempworldPos.y, 0f);
        for (int i = 1; i <= Mathf.FloorToInt(DontDestroy.players.Count/2); i++)
        {
            if (DontDestroy.players.Count % 2 != 0 && i == 1)
            {
                _cardSpawn.Add(worldPos);
            }
            _cardSpawn.Add(worldPos + plusPos * i);
            _cardSpawn.Add(worldPos + plusPos * -i);
        }
        foreach (var player in DontDestroy.players)
        {
            Debug.Log(plusPos);
        }
        for (int i = 0; i < DontDestroy.players.Count; i++)
        {
            AddCardView(DontDestroy.players[i], _cardSpawn[i]);
        }
    }

    void Update()
    {
        
    }
    private void AddCardView(Player player, Vector3 cardSpawn)
    {
        var view = Instantiate(_cardView, cardSpawn, Quaternion.identity);
        view.CardRender(player);
        //_cardView.GetComponent<>
    }
}
