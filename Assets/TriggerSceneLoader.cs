using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneLoader : MonoBehaviour
{

    public string sceneToLoad; // Название сцены, которую нужно загрузить

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Проверяем, если в зону входит объект с тегом "Player"
        {
            SceneManager.LoadScene(sceneToLoad); // Загружаем указанную сцену
        }
    }
}

