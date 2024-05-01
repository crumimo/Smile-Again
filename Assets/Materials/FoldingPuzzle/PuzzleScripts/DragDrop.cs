using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{ public GameObject objectToDrag;
    public GameObject ObjectDragToPos;

    public float Dropdistance;

    public bool isLocked;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    Vector2 objectInitPos;
    bool isDragging = false;

    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
    }

    void Update()
    {
        if (isDragging && !isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
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

        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);
        if (Distance < Dropdistance)
        {
            isLocked = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
            _source.PlayOneShot(_dropClip);
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
            _source.PlayOneShot(_dropClip);
        }
    }
}