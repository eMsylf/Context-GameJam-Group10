using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Crafting Crafting;
    public InventorySlotScript[] InventorySlots;
    public GameObject[] Items;
    public Transform Player;

    private void Awake() {
        
    }

    private void Update() {
        
    }

    public void AddToInventory(GameObject item, int slot) {
        InventorySlotScript currentSlot = InventorySlots[slot];
        InventorySlotScript currentSlotScript = currentSlot.GetComponent<InventorySlotScript>();
        Image currentSlotImage = currentSlot.GetComponent<InventorySlotScript>().ItemImage;
        Button currentSlotRemoveButton = currentSlot.GetComponent<InventorySlotScript>().ItemRemoveButton;
        Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;

        currentSlotScript.HeldObject = item;
        currentSlotScript.ItemImage.enabled = true;
        currentSlotScript.ItemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;

        currentSlotRemoveButton.interactable = true;
    }

    public void RemoveFromInventory(int slot) {
        InventorySlotScript currentSlotScript = InventorySlots[slot].GetComponent<InventorySlotScript>();
        GameObject item = currentSlotScript.HeldObject;
        
        item.SetActive(true);
        item.transform.position = Player.position;
        Items[slot] = null;
        Debug.Log("Dropped " + item.name);

        currentSlotScript.ItemImage.enabled = false;
        currentSlotScript.GetComponent<InventorySlotScript>().ItemRemoveButton.interactable = false;

        Crafting.RemoveFromCraftingMenu(0);
        Crafting.RemoveFromCraftingMenu(1);

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
                Crafting.Items[i] = InventorySlots[i].HeldObject;
                // Set the image of the crafting slot
                Crafting.SetSlotImage(i, InventorySlots[slot].GetComponent<InventorySlotScript>().ItemImage.sprite);
                return;
            }
        }
    }
}
