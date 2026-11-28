using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CardGame : MonoBehaviour
{
    SaveLoader saveLoader = new SaveLoader();
    private void Awake()
    {
        saveLoader.Load();
        Debug.Log(DontDestroy.lastPlayerID);
        DontDestroy.lastActiveScene = SceneManager.GetActiveScene().buildIndex;
    }

}
