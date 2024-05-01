using UnityEngine;
using UnityEngine.UI;

public class CloseCanvasButton : MonoBehaviour
{
    public Button closeButton;
    public GameObject canvasToClose;

    void Start()
    {
        closeButton.onClick.AddListener(CloseCanvas);
    }

    void CloseCanvas()
    {
        canvasToClose.SetActive(false);
    }
}

