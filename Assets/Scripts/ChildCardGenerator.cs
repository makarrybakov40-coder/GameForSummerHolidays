using UnityEngine;

public class ChildCardGenerator : MonoBehaviour
{
    [SerializeField] private CardView _cardView;
    private Vector2 _cardSpawn;
    //[SerializeField] private GameObject _cardConteiner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cardSpawn = this.transform.position;
        var view = Instantiate(_cardView, _cardSpawn, Quaternion.identity);
        //_cardView.CardRender()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
