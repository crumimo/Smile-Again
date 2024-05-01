using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInv : MonoBehaviour
{
    void Start()
    {
        // Подписываемся на событие загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Вызываем метод LoadInventory() после загрузки сцены
        InventorySaveLoad.Instance.LoadInventory();

        // Деактивируем канву инвентаря, если она активна
        if (InventoryManager.Instance.isInventoryActive)
        {
            InventoryManager.Instance.ToggleInventory();
        }
    }
    
}