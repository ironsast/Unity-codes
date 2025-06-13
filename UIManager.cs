using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Ссылка на текст очков
    public Text scoreText;
    // Ссылка на текст жизней
    public Text livesText;

    // Установить значение очков
    public void SetScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    // Установить значение жизней
    public void SetLives(int lives)
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}
