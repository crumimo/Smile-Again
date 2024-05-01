using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3; // Максимальное здоровье врага
    private int currentHealth; // Текущее здоровье врага

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем начальное здоровье
    }

    // Функция для получения урона
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Уменьшаем здоровье врага на величину damage

        // Проверяем, жив ли враг после получения урона
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Функция, которая вызывается при смерти врага
    void Die()
    {
        // Дополнительные действия при смерти врага
        Destroy(gameObject); // Уничтожаем объект врага
    }
}