using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public string targetSceneName;

   // Присвойте ваш префаб инвентаря в редакторе Unity
   public GameObject inventoryPrefab;

   // Вызывается для переноса игрока в другую сцену
   public void LoadTargetScene()
   {
      SceneManager.LoadScene(targetSceneName);

      // Создаем экземпляр инвентаря из префаба, если он присутствует
      if (inventoryPrefab != null)
      {
         Instantiate(inventoryPrefab);
      }
   }
}
