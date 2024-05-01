using UnityEngine;
using UnityEngine.UI;

public class PlayerPixel : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения игрока
    public Rigidbody2D rb;
    public Animator animator;
    public StartPixelGame deathMenu;

    public int health = 3; // Максимальное здоровье игрока
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject bulletPrefab; // Префаб объекта-пули
    public Transform firePoint; // Точка, откуда будет происходить выстрел

    private bool canTakeDamage = true; // Флаг, позволяющий нанести урон

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    
        Vector3 direction = Vector3.up;
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }

        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            canTakeDamage = false; // Устанавливаем флаг, чтобы предотвратить повторное нанесение урона
            Invoke("ResetDamageFlag", 3f); // Запускаем метод ResetDamageFlag через 3 секунды
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void ResetDamageFlag()
    {
        canTakeDamage = true; // Устанавливаем флаг обратно в true для возможности новой атаки
    }

    void Die()
    {
        Debug.Log("Player died!");
        deathMenu.ShowDeathMenu();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
