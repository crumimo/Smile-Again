using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float fallSpeed = 3f; // Скорость падения блока
    public GameManager.Direction direction; // Направление стрелки
    public KeyCode keyToPress; // Клавиша, которую нужно нажать
    public int blockID; // Уникальный идентификатор блока

    private bool isDestroyable = false; // Флаг, указывающий, может ли блок быть уничтожен

    void Update()
    {
        // Падение блока
        Fall();

        // Проверяем нажатие клавиши
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(keyToPress) && isDestroyable)
        {
            if (GameManager.Instance.CheckInput(blockID, direction)) // Проверка направления клавиши
            {
                Debug.Log("Player pressed the correct key for block ID: " + blockID + ", direction: " + direction.ToString());
                PlayDestroySound();
                Destroy(gameObject);
            }
        }
    }

    void Fall()
    {
        // Смещаем блок вниз на fallSpeed единиц за секунду
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Если блок вышел за пределы экрана внизу, уничтожаем его
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Метод для установки блока в состояние, в котором он может быть уничтожен
    public void SetDestroyable(bool value)
    {
        isDestroyable = value;
    }

    // Метод для воспроизведения звукового эффекта уничтожения блока
    private void PlayDestroySound()
    {
        // Получаем компонент AudioSource из пустого объекта на сцене
        AudioSource audioSource = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();

        // Воспроизводим звуковой эффект
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}