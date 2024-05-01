using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    public GameObject slotButtonPrefab;

    private void Start()
    {
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            inventory = playerObject.GetComponent<Inventory>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            AddToInventory();
        }
    }

    private void AddToInventory()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (!inventory.isFull[i])
            {
                inventory.isFull[i] = true;
                GameObject slotButton = Instantiate(slotButtonPrefab, inventory.slots[i].transform);
                // Если предмет представлен изображением на кнопке, можно скопировать изображение на созданный слот:
                // slotButton.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                Destroy(gameObject); // Удаляем объект, который был подобран.
                break;
            }
        }
    }
}