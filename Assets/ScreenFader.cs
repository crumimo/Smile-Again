using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Ensure this line is present for IEnumerator
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.5f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut(string targetSceneName)
    {
        float alpha = fadeImage.color.a;
        while (fadeImage.color.a < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(targetSceneName);
    }

    public IEnumerator FadeIn()
    {
        float alpha = fadeImage.color.a;
        while (fadeImage.color.a > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
