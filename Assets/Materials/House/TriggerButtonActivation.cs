using UnityEngine;

public class TriggerButtonActivation : MonoBehaviour
{
    public GameObject canvasWithButton;
    private Animator animator;

    void Start()
    {
        // Получаем компонент аниматора из канваса
        animator = canvasWithButton.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Активируем канвас
            canvasWithButton.SetActive(true);
            // Устанавливаем параметр "isActive" в true для активации анимации
            animator.SetBool("StartLook", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Устанавливаем параметр "isActive" в false для деактивации анимации
            animator.SetBool("StartLook", false);
        }
    }
}

