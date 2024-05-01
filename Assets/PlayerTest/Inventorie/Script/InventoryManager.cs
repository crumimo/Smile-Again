using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Canvas inventoryCanvas; // Ссылка на канву инвентаря
    public bool isInventoryActive { get; private set; } // Геттер для поля isInventoryActive

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Убедимся, что канва инвентаря инициализирована
        if (inventoryCanvas == null)
        {
            Debug.LogError("Inventory canvas is not assigned.");
        }
        else
        {
            // Сделаем канву инвентаря неактивной при запуске игры
            inventoryCanvas.gameObject.SetActive(false);
            isInventoryActive = false; // Устанавливаем начальное значение
        }
    }

    private void Update()
    {
        // Обработка нажатия клавиши Tab для активации/деактивации инвентаря
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    // Метод для активации/деактивации канвы инвентаря
    public void ToggleInventory()
    {
        isInventoryActive = !isInventoryActive;
        inventoryCanvas.gameObject.SetActive(isInventoryActive);
    }
}