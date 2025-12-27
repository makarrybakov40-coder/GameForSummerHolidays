using UnityEngine;

public class Game : MonoBehaviour
{
    private Player _activePlayer;

    public void PlayerSelect(Player player)
    {
        _activePlayer = player;
    }

    public void PLayerUnSelect()
    {
        _activePlayer = null;
    }

    public Player ActivePlayer()
    {
        return _activePlayer;
    }
}
