using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickToOpenPrefab : MonoBehaviour
{
    [SerializeField] private GameObject newPrefab;

    public void OnPointerClick()
    {
        Debug.Log("Событие OnPointerClick вызвано.");

        // Создаем новый объект из префаба
        GameObject newObject = Instantiate(newPrefab, transform.position, Quaternion.identity);

        Debug.Log("Новый объект создан.");

        // Уничтожаем текущий объект (Image)
        Destroy(gameObject);

        Debug.Log("Текущий объект уничтожен.");
    }
}