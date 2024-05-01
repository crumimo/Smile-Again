using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public GameObject canvasToOpen;

    private void Start()
    {
        button.onClick.AddListener(OpenCanvas);
    }

    void OpenCanvas()
    {
        canvasToOpen.SetActive(true);
    }
}