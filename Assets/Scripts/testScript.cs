// PlayerSelectionController.cs
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerSelectionController2 : MonoBehaviour
{
    [Header("Настройки")]
    public List<Player> players = new List<Player>();
    public LayerMask playerLayer;
    public LayerMask groundLayer;

    [Header("Визуальные эффекты")]
    public Color selectedColor = Color.yellow;
    public Color normalColor = Color.white;
    public GameObject selectionCirclePrefab;

    [Header("UI")]
    public Text selectedPlayerText;

    // Текущее состояние
    private Player selectedPlayer = null;
    private Dictionary<Player, GameObject> selectionIndicators = new Dictionary<Player, GameObject>();

    PlayerMovement playerMovement;

    void Start()
    {
        CreateSelectionIndicators();
        DeselectAllPlayers();

        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.IsMoving();
    }

    void Update()
    {
        // Клик для выбора/снятия выбора
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }

        // Если есть выбранный игрок, обрабатываем его ход
        if (selectedPlayer != null)
        {
            HandleSelectedPlayer();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, playerLayer);

        if (hit.collider != null)
        {
            // Кликнули по игроку
            Player clickedPlayer = hit.collider.GetComponent<Player>();
            if (clickedPlayer != null)
            {
                SelectPlayer(clickedPlayer);
            }
        }
        else
        {
            // Кликнули по пустому месту
            RaycastHit2D groundHit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, groundLayer);
            if (groundHit.collider != null)
            {
                // Снимаем выделение
                DeselectAllPlayers();
            }
        }
    }

    void HandleSelectedPlayer()
    {
        if (selectedPlayer == null) return;

        // Обрабатываем клики по кругам пути только для выбранного игрока
        if (Input.GetMouseButtonDown(1)) // Правый клик для движения
        {
            HandlePlayerMovementClick();
        }
    }

    void HandlePlayerMovementClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            PathCircle circle = hit.collider.GetComponent<PathCircle>();
            if (circle != null && playerMovement.IsMoving())
            {
                // Находим этот круг в пути выбранного игрока
                int circleIndex = FindCircleIndexInPlayerPath(selectedPlayer, circle.transform);
                if (circleIndex != -1)
                {
                    // Игрок начинает движение к этому кругу
                    selectedPlayer.MoveAlongPath(circleIndex);
                }
            }
        }
    }

    void SelectPlayer(Player player)
    {
        // Снимаем выделение со всех
        DeselectAllPlayers();

        // Выделяем выбранного игрока
        selectedPlayer = player;

        // Включаем индикатор выбора
        if (selectionIndicators.ContainsKey(player))
        {
            selectionIndicators[player].SetActive(true);
        }

        // Изменяем цвет игрока
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = selectedColor;
        }

        Debug.Log($"Выбран игрок: {(player)}");
    }

    void DeselectAllPlayers()
    {
        // Возвращаем обычный цвет всем игрокам
        foreach (var player in players)
        {
            if (player == null) continue;

            SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = normalColor;
            }

            // Выключаем индикаторы
            if (selectionIndicators.ContainsKey(player))
            {
                selectionIndicators[player].SetActive(false);
            }
        }

        selectedPlayer = null;
        Debug.Log("Выделение снято");
    }


    void CreateSelectionIndicators()
    {
        foreach (var player in players)
        {
            if (player == null) continue;

            if (selectionCirclePrefab != null)
            {
                GameObject indicator = Instantiate(selectionCirclePrefab, player.transform);
                indicator.transform.localPosition = Vector3.zero;
                indicator.transform.localScale = Vector3.one * 1.2f;
                indicator.SetActive(false);

                selectionIndicators[player] = indicator;
            }
        }
    }

    int FindCircleIndexInPlayerPath(Player player, Transform circleTransform)
    {
        if (player == null) return -1;

        // Используем рефлексию или публичный метод для доступа к пути
        // Предполагаем, что у PlayerController есть публичный метод GetPath()

        // Если у вас есть доступ к списку pathPoints:
        for (int i = 0; i < player.pathPoints.Count; i++)
        {
            if (player.pathPoints[i] == circleTransform)
            {
                return i;
            }
        }

        return -1;
    }


    // Публичные методы для UI кнопок
    public void SelectPlayerByIndex(int index)
    {
        if (index >= 0 && index < players.Count && players[index] != null)
        {
            SelectPlayer(players[index]);
        }
    }

    public void DeselectCurrentPlayer()
    {
        DeselectAllPlayers();
    }

}