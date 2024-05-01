using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public Animator chestAnimator; // Аниматор кнопки (шкатулки)

    // Переменные для предметов и их мест
    public GameObject item1;
    public Transform item1Location;
    public GameObject item2;
    public Transform item2Location;
    public GameObject item3;
    public Transform item3Location;

    private bool puzzleCompleted = false;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckPuzzleCompletion()
    {
        if (AllItemsPlacedCorrectly())
        {
            puzzleCompleted = true;
            Debug.Log("Puzzle completed!");
            chestAnimator.SetTrigger("Open");
        }
    }

    private bool AllItemsPlacedCorrectly()
    {
        // Проверяем, находятся ли все предметы на своих местах
        bool item1Correct = Vector3.Distance(item1.transform.position, item1Location.position) < 0.5f;
        bool item2Correct = Vector3.Distance(item2.transform.position, item2Location.position) < 0.5f;
        bool item3Correct = Vector3.Distance(item3.transform.position, item3Location.position) < 0.5f;

        // Если все предметы на своих местах, возвращаем true
        return item1Correct && item2Correct && item3Correct;
    }
}