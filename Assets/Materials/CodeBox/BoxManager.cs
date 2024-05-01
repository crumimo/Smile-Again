using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    public Switch[] switches; // Массив всех скриптов Switch
    public Image puzzleImage; // Image, который будет активирован после завершения загадки

    private bool puzzleCompleted = false;

    private void Update()
    {
        // Если все три загадки завершены, активируем Image
        if (!puzzleCompleted)
        {
            puzzleCompleted = CheckAllPuzzlesCompleted();
            if (puzzleCompleted)
            {
                // Вызываем метод ActivatePuzzleImage с задержкой в 1 секунду
                Invoke("ActivatePuzzleImage", 1f);
            }
        }
    }

    // Проверяет, все ли загадки завершены
    bool CheckAllPuzzlesCompleted()
    {
        foreach (var s in switches)
        {
            if (!s.IsPuzzleCompleted())
            {
                return false;
            }
        }
        return true;
    }

    // Активирует Image после завершения загадки
    void ActivatePuzzleImage()
    {
        if (puzzleImage != null)
        {
            puzzleImage.gameObject.SetActive(true);
        }
    }
}