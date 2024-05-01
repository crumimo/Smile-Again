using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject[] background;
    public Image[] correctSequence; // Правильная последовательность картинок
    private int index;
    private int currentIndex; // Индекс текущей картинки в последовательности

    private void Start()
    {
        index = 0;
        currentIndex = 0;
    }

    private void Update()
    {
        if (index < 0)
        {
            index = 0;
        }
        else if (index >= background.Length)
        {
            index = background.Length - 1;
        }

        for (int i = 0; i < background.Length; i++)
        {
            background[i].SetActive(i == index);
        }
    }

    public void Next()
    {
        index += 1;
        currentIndex = index;
        CheckSequence();
    }

    public void Previous()
    {
        index -= 1;
        currentIndex = index;
        CheckSequence();
    }

    private void CheckSequence()
    {
        if (currentIndex < correctSequence.Length)
        {
            if (background[index].GetComponent<Image>() == correctSequence[currentIndex])
            {
                currentIndex++;
                if (currentIndex >= correctSequence.Length)
                {
                    PuzzleCompleted();
                }
            }
            else
            {
                currentIndex = 0; // Сброс текущего индекса, если последовательность неправильная
            }
        }
    }

    // Метод, который проверяет, завершена ли загадка
    public bool IsPuzzleCompleted()
    {
        return currentIndex == correctSequence.Length;
    }

    private void PuzzleCompleted()
    {
        Debug.Log("Puzzle Completed!");
        // Дополнительные действия при завершении загадки
    }
}