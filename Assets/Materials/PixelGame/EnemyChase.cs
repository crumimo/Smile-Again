using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 5f; // Скорость движения врага
    public float chaseRange = 5f; // Расстояние, на котором враг начинает преследовать игрока
    public GameObject explosionPrefab; // Префаб эффекта взрыва

    private Transform player; // Ссылка на трансформ игрока
    private bool isChasing = false; // Флаг для определения, преследует ли враг игрока
    private Animator animator; // Ссылка на компонент аниматора

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isChasing)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Проверяем, находится ли игрок в пределах зоны видимости врага
            if (distanceToPlayer <= chaseRange)
            {
                isChasing = true; // Устанавливаем флаг, что враг начал преследовать игрока
                animator.SetBool("isChasing", true); // Включаем анимацию преследования
            }
        }

        if (isChasing)
        {
            // Преследуем игрока
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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