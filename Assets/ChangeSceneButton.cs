using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    // Название сцены, в которую вы хотите перейти
    public string sceneName;

    private Animator anim;
    //public Vector3 position;
    //public VectorValue playerStorage;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }

   

    public void ChangeScene()
    {
        //playerStorage.initialValue = position;
        // Сохранить инвентарь перед сменой сцены
        InventorySaveLoad.Instance.SaveInventory();

        // Загрузить сцену с указанным именем
        SceneManager.LoadScene(sceneName);
    }
}