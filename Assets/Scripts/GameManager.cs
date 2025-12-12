// GameManager.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [Header("Игроки")]
    public List<PlayerMovement> players = new List<PlayerMovement>();

    [Header("Настройки")]
    public bool autoSwitchTurn = true;
    public float turnDelay = 0.5f;

    [Header("UI")]
    public Text currentPlayerText;
    public Button nextPlayerButton;

    private int currentPlayerIndex = 0;

    void Start()
    {
        // Инициализируем игроков
        InitializePlayers();

        // Настраиваем UI
        SetupUI();

        // Начинаем с первого игрока
        SwitchToPlayer(0);
    }

    void InitializePlayers()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                // Разные цвета для игроков
                Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };
                players[i].SetColor(colors[i % colors.Length]);

                // Деактивируем всех
                players[i].SetActive(false);
            }
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
        }
    }

    void SetupUI()
    {
<<<<<<< HEAD
        if (nextTurnButton != null)
        {
            nextTurnButton.onClick.AddListener(NextTurn);
=======
        if (nextPlayerButton != null)
        {
            nextPlayerButton.onClick.AddListener(NextPlayer);
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
        }
    }

    void Update()
    {
<<<<<<< HEAD
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
=======
        // Если текущий игрок закончил движение и автосмена включена
        if (autoSwitchTurn && !players[currentPlayerIndex].IsMoving())
        {
            // Можно добавить задержку перед сменой игрока
        }

        // Обновляем UI
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        if (currentPlayerText != null && players.Count > currentPlayerIndex)
        {
            currentPlayerText.text = $"Ход: Игрок {currentPlayerIndex + 1}\n" +
                                   $"Круг: {players[currentPlayerIndex].GetCurrentCircle() + 1}";

            // Можно также изменить цвет текста под цвет игрока
        }
    }

    public void NextPlayer()
    {
        if (players[currentPlayerIndex].IsMoving()) return;

        // Переключаем на следующего игрока
        int nextIndex = (currentPlayerIndex + 1) % players.Count;
        SwitchToPlayer(nextIndex);
    }

    void SwitchToPlayer(int playerIndex)
    {
        // Деактивируем текущего игрока
        players[currentPlayerIndex].SetActive(false);

        // Активируем нового
        currentPlayerIndex = playerIndex;
        players[currentPlayerIndex].SetActive(true);

        Debug.Log($"Сейчас ходит Игрок {currentPlayerIndex + 1}");
    }

    // Метод для ручного добавления пути к игроку
    public void AssignPathToPlayer(int playerIndex, List<Transform> path)
    {
        if (playerIndex >= 0 && playerIndex < players.Count && players[playerIndex] != null)
        {
            players[playerIndex].SetPath(path);
        }
    }

    // Метод для быстрого создания цепочки путей в редакторе
    [ContextMenu("Найти все круги по порядку")]
    void FindAllCirclesInOrder()
    {
        // Находит все объекты с тегом "PathCircle" и сортирует их по имени
        GameObject[] allCircles = GameObject.FindGameObjectsWithTag("PathCircle");

        if (allCircles.Length == 0)
        {
            Debug.LogWarning("Не найдены объекты с тегом 'PathCircle'");
            return;
        }

        // Сортируем по имени (предполагаем, что в имени есть номер)
        System.Array.Sort(allCircles, (a, b) => {
            return a.name.CompareTo(b.name);
        });

        // Создаем список трансформов
        List<Transform> path = new List<Transform>();
        foreach (GameObject circle in allCircles)
        {
            path.Add(circle.transform);
        }

        Debug.Log($"Найдено {path.Count} кругов. Назначьте этот путь игрокам через AssignPathToPlayer.");
>>>>>>> 9f0d800e9c1bd3c22d260225912622676d7dd4c5
    }
}