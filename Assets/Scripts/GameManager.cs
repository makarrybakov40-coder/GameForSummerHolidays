// GameManager.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Настройки")]
    public int playersCount = 2;
    public Color[] playerColors = { Color.red, Color.blue, Color.green, Color.yellow };

    [Header("Префабы")]
    public GameObject playerPrefab;

    [Header("Ссылки")]
    public PathManager pathManager;
    public Text currentPlayerText;
    public Button nextTurnButton;

    private List<PlayerMovement> players = new List<PlayerMovement>();
    private int currentPlayerIndex = 0;
    private bool canMove = true;

    void Start()
    {
        CreatePlayers();
        SetupUI();
        ActivatePlayer(0);
    }

    void CreatePlayers()
    {
        for (int i = 0; i < playersCount; i++)
        {
            // Создаем игрока
            GameObject playerObj = Instantiate(playerPrefab);
            playerObj.name = $"Player_{i + 1}";

            PlayerMovement player = playerObj.GetComponent<PlayerMovement>();
            if (player == null) player = playerObj.AddComponent<PlayerMovement>();

            // Настраиваем игрока
            player.playerNumber = i + 1;
            player.playerColor = playerColors[i % playerColors.Length];

            // Даем путь
            List<Transform> path = pathManager.GetPathForPlayer(i);
            player.SetPath(path);

            players.Add(player);
        }
    }

    void SetupUI()
    {
        if (nextTurnButton != null)
        {
            nextTurnButton.onClick.AddListener(NextTurn);
        }
    }

    void Update()
    {
        if (!canMove) return;

        // Клик мышью для перемещения
        if (Input.GetMouseButtonDown(0))
        {
            players[currentPlayerIndex].HandleClick();
        }
    }

    public void NextTurn()
    {
        if (!players[currentPlayerIndex].isMoving)
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            ActivatePlayer(currentPlayerIndex);
        }
    }

    void ActivatePlayer(int index)
    {
        // Обновляем UI
        if (currentPlayerText != null)
        {
            currentPlayerText.text = $"Ход: Игрок {index + 1}";
            currentPlayerText.color = playerColors[index % playerColors.Length];
        }

        canMove = true;
    }

    public void PlayerFinishedMove()
    {
        // Игрок закончил ход, можно передавать ход
        canMove = true;
    }
}