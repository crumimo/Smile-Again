using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CastleDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image objectToDrag; // Используем Image вместо GameObject для работы с UI элементом
    public Transform ObjectDragToPos;
    public float Dropdistance;
    public bool isLocked;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;
    public Sprite newSprite; // Новый спрайт для замены
    Vector2 objectInitPos;
    bool isDragging = false;

    void Start()
    {
        objectInitPos = objectToDrag.rectTransform.position;
    }

    void Update()
    {
        if (isDragging && !isLocked)
        {
            objectToDrag.rectTransform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isLocked)
        {
            isDragging = true;
            _source.PlayOneShot(_pickUpClip);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        float Distance = Vector3.Distance(objectToDrag.rectTransform.position, ObjectDragToPos.position);
        if (Distance < Dropdistance)
        {
            isLocked = true;
            objectToDrag.rectTransform.position = ObjectDragToPos.position;
            _source.PlayOneShot(_dropClip);
            if (newSprite != null)
            {
                objectToDrag.sprite = newSprite;
            }
            PuzzleManager.Instance.CheckPuzzleCompletion();
        }
        else
        {
            objectToDrag.rectTransform.position = objectInitPos;
            _source.PlayOneShot(_dropClip);
        }
    }
}