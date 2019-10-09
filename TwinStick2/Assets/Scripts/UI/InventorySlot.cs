using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler, IDeselectHandler
{
    ItemData item;
    public Image icon;
    bool entered = false;
    private Inventory inventory;

    void Start()
    {
        inventory = GetComponentInParent<InventoryUI>().inventory;
    }

    void Update()
    {
        if (entered && Input.GetButtonDown("A"))
        {
            item = inventory.Equip(item);
        }

        if (entered && Input.GetButtonDown("Y"))
        {
            ClearSlot();
        }
    }

    public void AddItem (ItemData newItem)
    {
        item = newItem;
        icon.sprite = item.image;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        entered = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        entered = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        entered = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        entered = false;
    }
}
