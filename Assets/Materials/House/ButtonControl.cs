using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button button;
    private Animator animator;

    void Start()
    {
        animator = button.GetComponent<Animator>();
    }

    public void ActivateButton()
    {
        // Активируем кнопку
        button.gameObject.SetActive(true);
        // Запускаем анимацию активации
        animator.SetBool("StartLook", true);
    }

    public void DeactivateButton()
    {
        // Запускаем анимацию деактивации
        animator.SetBool("StartLook", false);
    }
}
