using UnityEngine;
using System.IO;
using System.Collections.Generic;

// 1. Класс с данными, которые нужно сохранить
[System.Serializable]
public class GameData
{
    public List<int> currentPosIndex;
    //public List<int> playerID;
    public List<Vector3> vector3;
    public List<float> speed;
    public List<float> pauseBeetwenPoints;
    public void Save()
    {
        for (int i = 0; i < Game.Instance.AllPlayers.Count; i++)
        {
            //playerID = Game.Instance.AllPlayers[0].PlayerID;
            currentPosIndex[i] = Game.Instance.AllPlayers[i].CurrentPositionIndex;
            vector3[i] = Game.Instance.AllPlayers[i].transform.position;
            speed[i] = Game.Instance.AllPlayers[i].PlayerMovement.moveSpeed;
            pauseBeetwenPoints[i] = Game.Instance.AllPlayers[i].PlayerMovement.pauseBetweenCircles;
        }
    }
    public void Load()
    {
        for (int i = 0; i < Game.Instance.AllPlayers.Count; i++)
        {
            Game.Instance.AllPlayers[i].CurrentPositionIndex = currentPosIndex[i];
            Game.Instance.AllPlayers[i].transform.position = vector3[i];
            Game.Instance.AllPlayers[i].PlayerMovement.moveSpeed = speed[i];
            Game.Instance.AllPlayers[i].PlayerMovement.pauseBetweenCircles = pauseBeetwenPoints[i];
        }
    }
}

public class JSON_file : MonoBehaviour
{
    private string savePath;
    public GameData data = new GameData(); // Текущие данные в игре

    void OnApplicationQuit()
    {
        Save();
    }

    // 2. Метод для сохранения
    public void Save()
    {
        savePath = System.IO.Path.Combine(Application.persistentDataPath, "gamesave.json");
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
        savePath = System.IO.Path.Combine(Application.persistentDataPath, "gamesave.json");
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