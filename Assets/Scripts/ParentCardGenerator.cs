using UnityEngine;

public class ParentCardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cardConteiner;
    [SerializeField] private CardView _cardView;
    private Vector2 _cardSpawn;
    void Start()
    {
        _cardSpawn = this.transform.position;
        foreach (var player in DontDestroy.players)
        {
            Debug.Log(player.PlayerName);
        }
        _cardSpawn = this.transform.position;
        for (int i = 0; i < DontDestroy.players.Count; i++)
        {
            AddCardView(DontDestroy.players[i]);
        }
    }

    void Update()
    {
        
    }
    private void AddCardView(Player player)
    {
        var view = Instantiate(_cardView, _cardSpawn, Quaternion.identity);
        view.CardRender(player);
        //_cardView.GetComponent<>
    }
}
