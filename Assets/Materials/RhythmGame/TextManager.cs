using TMPro;
using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textField; // Ссылка на текстовое поле TextMeshPro

    public string[] sentences; // Массив предложений, которые нужно вывести
    private int currentSentenceIndex = 0; // Текущий индекс предложения

    public float printSpeed = 0.05f; // Скорость печати текста

    void Start()
    {
        // Начинаем отображение текста
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        // Пока есть предложения для отображения
        while (currentSentenceIndex < sentences.Length)
        {
            // Отображаем текущее предложение посимвольно
            for (int i = 0; i <= sentences[currentSentenceIndex].Length; i++)
            {
                textField.text = sentences[currentSentenceIndex].Substring(0, i);
                yield return new WaitForSeconds(printSpeed);
            }

            // Ждем некоторое время после окончания печати
            yield return new WaitForSeconds(1f);

            // Переходим к следующему предложению
            currentSentenceIndex++;
        }
    }
}