using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogueSceneLoader : MonoBehaviour
{
    // Метод для загрузки указанной сцены
    public void LoadNextScene(string sceneName)
    {
        // Загружаем указанную сцену по ее имени
        SceneManager.LoadScene(sceneName);
    }
}
