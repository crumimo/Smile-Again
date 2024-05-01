using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f; // Скорость перемещения объекта
    public float stoppingDistance = 1f; // Расстояние, на котором объект останавливается
    public string playerTag = "Player"; // Тег игрока

    private Transform playerTransform; // Ссылка на трансформ игрока
    private Animator animator; // Ссылка на компонент аниматора
    private SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer

    void Start()
    {
        // Получаем ссылки на компоненты
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Ищем игрока по тегу
        if (playerTransform == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
            if (playerObject != null)
            {
                playerTransform = playerObject.transform;
            }
        }

        if (playerTransform != null)
        {
            // Перемещаем объект к игроку, только если расстояние между ними больше stoppingDistance
            if (Vector2.Distance(transform.position, playerTransform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

                // Если объект движется, включаем анимацию ходьбы
                animator.SetBool("Walking", true);

                // Определяем направление движения игрока
                Vector3 direction = (playerTransform.position - transform.position).normalized;

                // Определяем направление взгляда кота
                if (direction.x > 0)
                {
                    spriteRenderer.flipX = false; // Взгляд направлен вправо
                }
                else if (direction.x < 0)
                {
                    spriteRenderer.flipX = true; // Взгляд направлен влево
                }
            }
            else
            {
                // Останавливаем движение объекта и отключаем анимацию ходьбы
                animator.SetBool("Walking", false);
            }
        }
    }
}
