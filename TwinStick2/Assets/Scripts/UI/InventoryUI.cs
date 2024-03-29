﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject tooltip;

    public Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>(); 
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            tooltip.SetActive(!tooltip.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
