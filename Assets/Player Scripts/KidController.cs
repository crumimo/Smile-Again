using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true; // Переменная для отслеживания направления персонажа

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Получаем ввод от игрока
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Устанавливаем скорость анимации в зависимости от скорости движения
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Движение персонажа
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Поворот персонажа
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    // Функция для поворота персонажа
    private void Flip()
    {
        facingRight = !facingRight; // Изменяем направление персонажа
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Инвертируем масштаб по оси X
        transform.localScale = theScale;
    }
}
