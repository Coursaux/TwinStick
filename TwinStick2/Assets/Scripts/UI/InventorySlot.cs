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
    private Text secondary;
    private Text grenade;
    private Text melee;

    private float equipTime = -10f;

    void Start()
    {
        inventory = GetComponentInParent<InventoryUI>().inventory;
        looking = GameObject.Find("LookingText").GetComponent<Text>();
        equipped = GameObject.Find("EquippedText").GetComponent<Text>();
        secondary = GameObject.Find("SecondaryText").GetComponent<Text>();
        grenade = GameObject.Find("GrenadeText").GetComponent<Text>();
        melee = GameObject.Find("MeleeText").GetComponent<Text>();
    }

    void Update()
    {
        equipped.text = "Equipped\n" + inventory.primary.name + "\nDamage: " + inventory.primary.damage + "\nRoF: " + inventory.primary.attackSpeed.ToString("F2") + "\nAccuracy: " + inventory.primary.accuracy.ToString("F2");
        secondary.text = "Secondary\n" + inventory.secondary.name + "\nDamage: " + inventory.secondary.damage + "\nRoF: " + inventory.secondary.attackSpeed.ToString("F2") + "\nAccuracy: " + inventory.secondary.accuracy.ToString("F2");
        if (Time.time > equipTime + 0.2f && entered && (Input.GetButtonDown("A") || Input.GetButtonDown("ShootM+K")))
        {
            equipTime = Time.time;
            if (!(item == null)) 
                item = inventory.Equip(item);
        }

        if (Time.time > equipTime + 0.2f && entered && (Input.GetButtonDown("Y") || Input.GetButtonDown("MeleeM+K")))
        {
            equipTime = Time.time;
            ClearSlot();
        }

        if (entered && item != null)
        {
            looking.text = "Highlighted\n" + item.name + "\nDamage: " + item.damage + "\nRoF: " + item.attackSpeed.ToString("F2") + "\nAccuracy: " + item.accuracy.ToString("F2");
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
