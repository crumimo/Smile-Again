using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public string sceneName; // Имя сцены, на которую нужно перейти
    public float delayInSeconds = 60f; // Задержка в секундах перед переходом

    void Start()
    {
        StartCoroutine(DelayedSceneTransition());
    }

    IEnumerator DelayedSceneTransition()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneName);
    }
}