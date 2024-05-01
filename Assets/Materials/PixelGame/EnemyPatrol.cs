using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Скорость движения врага
    public float patrolDistance = 5f; // Расстояние, на которое будет перемещаться враг
    public float verticalSpeed = 1f; // Скорость вертикального движения врага
    public Animator animator; // Ссылка на компонент аниматора
    public GameObject explosionPrefab; // Префаб эффекта взрыва

    private bool movingUp = true; // Флаг направления вертикального движения
    private Vector3 startPos; // Начальная позиция врага

    void Start()
    {
        startPos = transform.position; // Сохраняем начальную позицию
    }

    void Update()
    {
        // Перемещение врага по горизонтали
        if (movingUp)
        {
            transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
            animator.SetFloat("Vertical", 1f); // Устанавливаем значение параметра "Vertical" аниматора для воспроизведения анимации движения вверх
        }
        else
        {
            transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
            animator.SetFloat("Vertical", -1f); // Устанавливаем значение параметра "Vertical" аниматора для воспроизведения анимации движения вниз
        }

        // Проверка достижения предела патрулирования по вертикали
        if (Mathf.Abs(transform.position.y - startPos.y) >= patrolDistance)
        {
            // Изменение направления движения по вертикали
            movingUp = !movingUp;
        }

        // Проверка достижения предела патрулирования по горизонтали
        if (Mathf.Abs(transform.position.x - startPos.x) >= patrolDistance)
        {
            // Изменение направления движения по горизонтали
            startPos = transform.position; // Обновляем начальную позицию
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем столкновение с пулей
        if (other.CompareTag("Bullet"))
        {
            // Создаем эффект взрыва в месте столкновения
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Уничтожаем пулю
            Destroy(other.gameObject);

            // Можно добавить код для нанесения урона врагу, если это необходимо
        }
    }
}
