using UnityEngine;

public class PlayerInputZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            // Активируем триггер у блока, находящегося в зоне нажатия
            other.isTrigger = true;

            // Меняем цвет блока на желтый
            SpriteRenderer spriteRenderer = other.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.yellow;
            }

            // Устанавливаем блок в состояние, в котором он может быть уничтожен
            BlockController blockController = other.GetComponent<BlockController>();
            if (blockController != null)
            {
                blockController.SetDestroyable(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            // Деактивируем триггер у блока, покидающего зону нажатия
            other.isTrigger = false;

            // Меняем цвет блока на белый
            SpriteRenderer spriteRenderer = other.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.white;
            }

            // Устанавливаем блок в состояние, в котором он не может быть уничтожен
            BlockController blockController = other.GetComponent<BlockController>();
            if (blockController != null)
            {
                blockController.SetDestroyable(false);
            }
        }
    }
}