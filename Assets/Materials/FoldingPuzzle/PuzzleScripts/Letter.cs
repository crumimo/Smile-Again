using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public string noteText = "Ваш текст записки";
    public Text noteTextUI; // Ссылка на элемент Text в интерфейсе

    private void Start()
    {
        noteTextUI.gameObject.SetActive(false); // Начально скрываем текст
    }

    private void OnMouseOver()
    {
        // Подсветка при наведении
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void OnMouseExit()
    {
        // Убираем подсветку
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        // Открываем окно с текстом записки
        ShowNoteDialog();
    }

    private void ShowNoteDialog()
    {
        // Включаем элемент Text и устанавливаем текст
        noteTextUI.gameObject.SetActive(true);
        noteTextUI.text = noteText;
    }
}

