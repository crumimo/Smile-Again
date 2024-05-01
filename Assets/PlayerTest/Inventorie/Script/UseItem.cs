using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemType
{
    Key,
    SmallArrow,
    BigArrow,
    Pesok1,
    Pesok2,
    Pesok3
}

public class UseItem : MonoBehaviour, IPointerClickHandler
{
    public ItemType itemType; 

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Use(eventData.pointerPress);
        }
    }

    private void Use(GameObject clickedObject)
    {
        Transform parent = clickedObject.transform.parent;
        Inventory inventory = FindObjectOfType<Inventory>(); // Получаем ссылку на инвентарь
        if (inventory == null)
        {
            Debug.LogError("Inventory object not found!");
            return;
        }

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].transform == parent)
            {
                inventory.isFull[i] = false;

                switch (itemType)
                {
                    case ItemType.Key:
                        // Обработка использования ключа
                        break;
                    case ItemType.SmallArrow:
                        if (Clock.Instance != null)
                        {
                            Clock.Instance.ActivateSmallArrow();
                            Destroy(clickedObject); // Удаляем объект только после активации стрелки
                        }
                        else
                        {
                            Debug.LogError("Clock instance is null!");
                        }
                        break;
                    case ItemType.BigArrow:
                        if (Clock.Instance != null)
                        {
                            Clock.Instance.ActivateBigArrow();
                            Destroy(clickedObject); // Удаляем объект только после активации стрелки
                        }
                        else
                        {
                            Debug.LogError("Clock instance is null!");
                        }
                        break;
                    case ItemType.Pesok1:
                        GameObject pesok1Object = GameObject.FindGameObjectWithTag("Pesok1");
                        if (pesok1Object != null)
                        {
                            pesok1Object.SetActive(true);
                            Debug.Log("Pesok1 object activated!");
                        }
                        else
                        {
                            Debug.LogError("Pesok1 object not found!");
                        }
                        break;
                    case ItemType.Pesok2:
                        GameObject pesok2Object = GameObject.FindGameObjectWithTag("Pesok2");
                        if (pesok2Object != null)
                        {
                            pesok2Object.SetActive(true);
                            Debug.Log("Pesok2 object activated!");
                        }
                        else
                        {
                            Debug.LogError("Pesok2 object not found!");
                        }
                        break;
                    case ItemType.Pesok3:
                        GameObject pesok3Object = GameObject.FindGameObjectWithTag("Pesok3");
                        if (pesok3Object != null)
                        {
                            pesok3Object.SetActive(true);
                            Debug.Log("Pesok3 object activated!");
                        }
                        else
                        {
                            Debug.LogError("Pesok3 object not found!");
                        }
                        break;
                    
                    default:
                        Debug.LogError("Unknown item type!");
                        break;
                }

                break;
            }
        }
    }
}
