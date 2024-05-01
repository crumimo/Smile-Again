using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image firstImage; // Первая картинка
    public Image secondImage; // Вторая картинка
    public Collider2D clickableCollider; // Коллайдер области, на которой можно нажать

    private bool isFirstImageShown = false; // Флаг, указывающий, отображается ли первая картинка
    private bool isSecondImageShown = false; // Флаг, указывающий, отображается ли вторая картинка

    void Update()
    {
        // Проверяем, было ли нажатие кнопки мыши и обе картинки не были показаны
        if (Input.GetMouseButtonDown(0) && !isFirstImageShown && !isSecondImageShown)
        {
            // Получаем позицию клика мыши в мировых координатах
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Проверяем, попал ли клик в коллайдер
            if (clickableCollider.OverlapPoint(clickPosition))
            {
                Debug.Log("Click detected in the clickable area");
                // Показываем первую картинку
                firstImage.gameObject.SetActive(true);
                isFirstImageShown = true;
            }
            else
            {
                Debug.Log("Click outside the clickable area");
            }
        }
        // Проверяем, было ли нажатие кнопки мыши и первая картинка была показана, а вторая нет
        else if (Input.GetMouseButtonDown(0) && isFirstImageShown && !isSecondImageShown)
        {
            // Получаем позицию клика мыши в мировых координатах
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Проверяем, попал ли клик в коллайдер
            if (clickableCollider.OverlapPoint(clickPosition))
            {
                Debug.Log("Click detected in the clickable area");
                // Показываем вторую картинку
                secondImage.gameObject.SetActive(true);
                isSecondImageShown = true;
            }
            else
            {
                Debug.Log("Click outside the clickable area");
            }
        }
    }
}
