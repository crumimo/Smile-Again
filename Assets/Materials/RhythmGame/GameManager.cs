using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    // Метод для проверки правильности нажатой клавиши
    public bool CheckInput(int blockID, Direction direction)
    {
        // Получаем направление нажатой клавиши
        Direction pressedDirection = GetDirectionFromKey();

        // Сравниваем с правильным направлением
        return (pressedDirection == direction);
    }

    // Метод для определения направления нажатой клавиши
    private Direction GetDirectionFromKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return Direction.Right;
        }
        else
        {
            return Direction.None;
        }
    }
}