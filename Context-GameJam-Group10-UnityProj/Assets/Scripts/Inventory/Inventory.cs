using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Crafting Crafting;
    public InventorySlotScript[] InventorySlots;
    public Item[] Items;
    public Transform Player;

    private void Awake() {
        
    }

    private void Update() {
        
    }

    public void AddToInventory(Item item, int slot) {
        InventorySlotScript currentSlot = InventorySlots[slot];
        InventorySlotScript currentSlotScript = currentSlot.GetComponent<InventorySlotScript>();
        Image currentSlotImage = currentSlot.GetComponent<InventorySlotScript>().ItemImage;
        if (item == null) {
            Debug.Log("There's no item");
            return;
        }
        Sprite itemSprite = item.Sprite;

        currentSlot.GetComponent<InventorySlotScript>().ItemRemoveButton.interactable = true;

        currentSlotScript.HeldItem = item;
        Items[slot] = item;
        currentSlotScript.ItemImage.enabled = true;
        currentSlotScript.ItemImage.sprite = item.Sprite;
    }

    public void RemoveFromInventory(int slot) {
        RemoveFromInventory(slot, false);
    }

    public void RemoveFromInventory(int slot, bool useItem) {
        InventorySlotScript currentSlotScript;
        if (useItem) { // Destroy item
            currentSlotScript = InventorySlots[slot];
            //if (Crafting.IngredientSlots[slot] == null) {
            //    Debug.Log("Crafting slot " + slot + "is null");
            //    return;
            //}
            //if (Crafting.IngredientSlots[slot].InventorySlotReference == null) {
            //    Debug.Log("No inventory reference");
            //    return;
            //}
            
            Debug.Log("Using item");
            //Debug.Log("Used " + currentSlotScript.HeldItem.ItemName);

        } else { // Drop item
            currentSlotScript = InventorySlots[slot];
            currentSlotScript.HeldItem.gameObject.SetActive(true);
            currentSlotScript.HeldItem.transform.position = Player.position;
            Debug.Log("Dropping item");
            //Debug.Log("Dropped " + currentSlotScript.HeldItem.ItemName);
        }
        Items[slot] = null;

        if (currentSlotScript == null) {
            Debug.Log("No slot script");
            return;
        } else if (currentSlotScript.ItemImage == null) {
            Debug.Log("No item image in this slot script");
        }
        currentSlotScript.ItemImage.enabled = false;
        currentSlotScript.GetComponent<InventorySlotScript>().ItemRemoveButton.interactable = false;

        Crafting.RemoveFromCraftingMenu(0);
        Crafting.RemoveFromCraftingMenu(1);
        Crafting.ClearCombinedItem();

    }

    public void CopyToCraftingMenu(int slot) {
        for (int i = 0; i < Crafting.Items.Length -1; i++) {
            if (Items[slot] == null) {
                Debug.Log("This inventory slot is empty");
                return;
            }

            for (int j = 0; j < Crafting.Items.Length -1; j++) {
                if (Crafting.IngredientSlots[j].InventorySlotReference == InventorySlots[slot]) {
                    Debug.Log("This item has already been put into a crafting slot");
                    return;
                }
            }

            if (Items[slot].IsCombinedItem) {
                Debug.Log("This item cannot be used to craft");
                return;
            }

            if (Crafting.IngredientSlots[i].InventorySlotReference != null) {
                Debug.Log("This crafting slot already holds an item");
                if (i == Crafting.Items.Length - 1) {
                    Debug.Log("Crafting menu is full");
                }

            } else {
                Debug.Log("Copying item in slot " + slot + " to crafting menu");
                // Get references out to both the inventory slot and crafting slot
                InventorySlots[slot].CraftingSlotReference = Crafting.IngredientSlots[i];
                Crafting.IngredientSlots[i].InventorySlotReference = InventorySlots[slot];

                // Assign the object in the inventory to the crafting slot
                Crafting.Items[i] = InventorySlots[slot].HeldItem;
                // Set the image of the crafting slot
                Crafting.SetSlotImage(i, InventorySlots[slot].GetComponent<InventorySlotScript>().ItemImage.sprite);

                if (Crafting.IngredientSlots[0].InventorySlotReference != null 
                    && Crafting.IngredientSlots[1].InventorySlotReference != null) {
                    Crafting.ShowCombinedItem();
                }

                return;
            }
        }
    }
}
