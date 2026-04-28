using UnityEngine;
using System.IO;
using System.Collections.Generic;

// 1. Класс с данными, которые нужно сохранить
[System.Serializable]
public class GameData
{
    public int currentPosIndex;
    public int playerID;
    public void Save()
    {
        //for (int i = 0; i < Game.Instance.AllPlayers.Count; i++)
        //{
            playerID = Game.Instance.AllPlayers[0].PlayerID;
            currentPosIndex = Game.Instance.AllPlayers[0].CurrentPositionIndex;
        //}
    }
    public void Load()
    {
        //for (int i = 0; i < Game.Instance.AllPlayers.Count; i++)
        //{
        Game.Instance.AllPlayers[0].CurrentPositionIndex = currentPosIndex;
        //}
    }
}

public class JSON_file : MonoBehaviour
{
    private string savePath;
    public GameData data = new GameData(); // Текущие данные в игре

    void Start()
    {
        // Путь к файлу: на ПК это AppData, на Android — внутренняя папка игры
        savePath = System.IO.Path.Combine(Application.persistentDataPath, "gamesave.json");
        Load();
    }
    void OnDisable()
    {
        Save();
    }

    // 2. Метод для сохранения
    public void Save()
    {
        data.Save();
        // Превращаем объект в строку JSON
        string json = JsonUtility.ToJson(data, true);
        // Записываем строку в файл
        File.WriteAllText(savePath, json);
        Debug.Log("Игра сохранена в: " + savePath);
    }

    // 3. Метод для загрузки
    public void Load()
    {
        if (File.Exists(savePath))
        {
            // Читаем строку из файла
            string json = File.ReadAllText(savePath);
            // Перезаписываем наш объект данными из JSON
            JsonUtility.FromJsonOverwrite(json, data);
            data.Load();
            Debug.Log("Игра загружена");
        }
        else
        {
            Debug.LogWarning("Файл сохранения не найден");
        }
    }
}