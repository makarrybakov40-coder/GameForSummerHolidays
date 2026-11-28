using UnityEngine;
using System.Collections.Generic;

public class ParentCardGenerator : MonoBehaviour
{
    [SerializeField] private CardView _cardView;
    GameData gameData = new GameData();
    private List<Vector3> _cardSpawn = new List<Vector3>();
    private List<Sprite> _cardFace = new List<Sprite>();
    public List<Sprite> CardFace { get { return _cardFace; } }
    void Start()
    {
        Camera cam = Camera.main;
        Vector3 worldPosition = Camera.main.transform.position;
        Vector3 centerPos = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Vector3 plusPos = new Vector3(cam.orthographicSize * 2 * cam.aspect / DontDestroy.cards.Count, 0f , 0f);
        Vector3 tempworldPos = Camera.main.ScreenToWorldPoint(centerPos);

        Vector3 worldPos = new Vector3(tempworldPos.x, tempworldPos.y, 0f);
        for (int i = 1; i <= Mathf.FloorToInt(DontDestroy.cards.Count/2); i++)
        {
            if (DontDestroy.cards.Count % 2 != 0 && i == 1)
            {
                _cardSpawn.Add(worldPos);
            }
            _cardSpawn.Add(worldPos + plusPos * i);
            _cardSpawn.Add(worldPos + plusPos * -i);
        }
              
        for (int i = 0; i < DontDestroy.cards.Count; i++)
        {
            AddCardView(i, _cardSpawn[i]);
        }
    }
    private void AddCardView(int ID, Vector3 cardSpawn)
    {
        var view = Instantiate(_cardView, cardSpawn, Quaternion.identity);
        _cardFace.Add(view.PlayerFace);
        //view.CardRender(player);
        view.SetCardData(DontDestroy.cards[ID]);
    }
}
