using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventorySaveLoad : MonoBehaviour
{
    private static InventorySaveLoad instance;
    public static InventorySaveLoad Instance { get { return instance; } }

    private Canvas inventoryCanvas; // Ссылка на объект Canvas инвентаря

    public string inventoryDataKey = "InventoryData"; // Ключ для сохранения данных инвентаря в PlayerPrefs

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Удаляем этот объект, если уже существует другой экземпляр
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Делаем этот объект неуничтожаемым при смене сцены
        }

        // Проверяем наличие объекта Canvas инвентаря при запуске игры
        FindInventoryCanvas();
    }

    private void FindInventoryCanvas()
    {
        inventoryCanvas = GameObject.FindWithTag("InventoryCanvas")?.GetComponent<Canvas>();

        if (inventoryCanvas != null)
        {
            Debug.Log("Inventory canvas found in the scene.");
        }
        else
        {
            Debug.LogWarning("Inventory canvas not found in the scene.");
        }
    }
    // Метод сохранения инвентаря
    public void SaveInventory()
    {
        if (InventoryManager.Instance.inventoryCanvas == null || !InventoryManager.Instance.inventoryCanvas.gameObject.activeInHierarchy)
        {
            Debug.LogWarning("Inventory canvas is not active or not assigned.");
            return;
        }


        string inventoryData = "";

        // Проходимся по всем дочерним объектам Canvas
        foreach (Transform item in inventoryCanvas.transform)
        {
            Image image = item.GetComponent<Image>();
            if (image != null && image.enabled)
            {
                // Если у объекта включен компонент Image, сохраняем его имя
                inventoryData += item.name + ",";
            }
        }

        // Сохраняем данные инвентаря в PlayerPrefs
        PlayerPrefs.SetString(inventoryDataKey, inventoryData);
        PlayerPrefs.Save(); // Обязательно сохраняем изменения

        Debug.Log("Inventory saved: " + inventoryData);
    }

    // Метод загрузки инвентаря
    public void LoadInventory()
    {
        if (inventoryCanvas == null)
        {
            Debug.LogWarning("Inventory canvas is not assigned.");
            return;
        }

        // Загружаем данные инвентаря из PlayerPrefs
        string inventoryData = PlayerPrefs.GetString(inventoryDataKey);

        Debug.Log("Loaded inventory data: " + inventoryData);

        // Получаем массив имен объектов из строки данных инвентаря
        string[] itemNames = inventoryData.Split(',');

        // Проходимся по всем дочерним объектам Canvas
        foreach (Transform item in inventoryCanvas.transform)
        {
            Image image = item.GetComponent<Image>();
            if (image != null)
            {
                // Отключаем все объекты в инвентаре
                image.enabled = false;

                // Если имя объекта есть в данных инвентаря, включаем его
                foreach (string itemName in itemNames)
                {
                    if (itemName == item.name)
                    {
                        image.enabled = true;
                        break;
                    }
                }
            }
        }

        Debug.Log("Inventory loaded.");
    }
    
    
}
