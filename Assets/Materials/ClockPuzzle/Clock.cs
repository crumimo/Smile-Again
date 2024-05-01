using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public GameObject smallArrow;
    public GameObject bigArrow;
    public GameObject puzzleCompleteImage; 

    private float minutesPassed = 0.0f;
    private bool puzzleCompleted = false;
    private bool smallArrowActive = false;
    private bool bigArrowActive = false;

    private static Clock instance;

    public static Clock Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Clock>();
            }
            return instance;
        }
    }

    private void Start()
    {
        hourHand.rotation = Quaternion.Euler(0, 0, 0);
        minuteHand.rotation = Quaternion.Euler(0, 0, 0);

        smallArrow.SetActive(false);
        bigArrow.SetActive(false);
        puzzleCompleteImage.SetActive(false);
    }

    private void Update()
    {
        if (puzzleCompleted) return;

        if (smallArrowActive && bigArrowActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                minuteHand.Rotate(Vector3.forward, -20f);
                minutesPassed += 5.0f;
                hourHand.Rotate(Vector3.forward, -5f);
            }
        }

        if (!puzzleCompleted && minutesPassed >= 180.0f)
        {
            puzzleCompleted = true;
            Debug.Log("Puzzle completed!");
            puzzleCompleteImage.SetActive(true);
        }
    }

    public void ActivateSmallArrow()
    {
        smallArrowActive = true;
        smallArrow.SetActive(true);
        CheckPuzzleCompleted();
    }

    public void ActivateBigArrow()
    {
        bigArrowActive = true;
        bigArrow.SetActive(true);
        CheckPuzzleCompleted();
    }

    private void CheckPuzzleCompleted()
    {
        if (smallArrowActive && bigArrowActive)
        {
            Debug.Log("Both arrows are active!");
        }
    }
}