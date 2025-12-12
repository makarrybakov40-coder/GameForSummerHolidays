// GameManager.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
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
        }
    }

    void SetupUI()
    {
        if (nextPlayerButton != null)
        {
            nextPlayerButton.onClick.AddListener(NextPlayer);
        }
    }

    void Update()
    {
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
    }
}