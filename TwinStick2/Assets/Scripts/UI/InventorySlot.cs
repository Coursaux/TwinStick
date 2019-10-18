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
    private Text looking;
    private Text equipped;

    void Start()
    {
        inventory = GetComponentInParent<InventoryUI>().inventory;
        looking = GameObject.Find("Looking").GetComponent<Text>();
        equipped = GameObject.Find("Equipped").GetComponent<Text>();
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

        if (entered && item != null)
        {
            looking.text = "Highlighted\n" + item.name + "\nDamage: " + item.damage + "\nRoF: " + item.attackSpeed.ToString("F2") + "\nAccuracy: " + item.accuracy.ToString("F2");
            equipped.text = "Eqipped\n" + inventory.primary.name + "\nDamage: " + inventory.primary.damage + "\nRoF: " + inventory.primary.attackSpeed.ToString("F2") + "\nAccuracy: " + inventory.primary.accuracy.ToString("F2");
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
        looking.text = "";
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
        looking.text = "";
    }
}
