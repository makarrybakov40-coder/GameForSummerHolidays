using UnityEngine;
using UnityEngine.UI;
using TMPro; // Удалите или закомментируйте, если используете обычный Text вместо TextMeshPro

public class CoinFlipGame : MonoBehaviour
{
    // Ссылки на элементы UI в инспекторе
    [SerializeField] private TMP_Text resultText; // Если обычный текст, замените TMP_Text на Text

    // Этот метод привязываем к Кнопке 1
    public void OnButtonOneClick()
    {
        PlayGame(1);
    }

    // Этот метод привязываем к Кнопке 2
    public void OnButtonTwoClick()
    {
        PlayGame(2);
    }

    private void PlayGame(int playerChoice)
    {
        // Генерация случайного числа (1 или 2)
        int flipResult = Random.Range(1, 3); // В Unity Random.Range для int включает нижнюю границу и исключает верхнюю

        // Проверка результата
        if (playerChoice == flipResult)
        {
            resultText.text = $"{flipResult}!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = $"{flipResult}";
            resultText.color = Color.red;
        }
    }
}
