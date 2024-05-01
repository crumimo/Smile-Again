using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPixelGame : MonoBehaviour
{
    public GameObject canvas; // Ссылка на объект канвы

    void Start()
    {
        canvas.SetActive(false); // Выключаем канву при запуске игры
    }

    public void ShowDeathMenu()
    {
        canvas.SetActive(true); // Включаем канву при смерти игрока
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагружаем текущую сцену
    }
}