using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Скорость пули
    public float maxLifetime = 10f; // Максимальное время жизни пули
    public int damage = 1; // Урон, наносимый пулей

    private float currentLifetime = 0f;
    
    private Vector3 direction;

    void Update()
    {
        // Движение пули в указанном направлении
        transform.position += transform.up * speed * Time.deltaTime;

        // Увеличиваем текущее время жизни пули
        currentLifetime += Time.deltaTime;

        // Проверяем, если текущее время жизни пули превысило максимальное время
        if (currentLifetime >= maxLifetime)
        {
            // Уничтожаем пулю
            Destroy(gameObject);
        }
    }
    
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // Нормализуем вектор направления
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка столкновения с врагами
        if (other.CompareTag("Enemy"))
        {
            // Получаем компонент здоровья врага
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                // Наносим урон врагу
                enemyHealth.TakeDamage(damage);
            }

            // Уничтожаем пулю
            Destroy(gameObject);
        }
    }
}