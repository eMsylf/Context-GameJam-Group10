using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {
    public Inventory Inventory;
    public CraftingRecipies CraftingRecipies;
    public CraftingSlotScript[] IngredientSlots;
    public OutcomeSlotScript OutcomeSlot;
    public Item[] Items;
    private Image IngredientSlotImage;

    private void Start() {
        ResetSlotImages();
        CraftingRecipies = GetComponent<CraftingRecipies>();
    }

    private void Update() {

    }

    public void ResetSlotImages() {
        for (int i = 0; i < Items.Length - 1; i++) {
            SetSlotImage(i, null);
        }
    }

    public void SetSlotImage(int slot, Sprite sprite) {
        if (sprite == null) {
            IngredientSlots[slot].ItemImage.enabled = false;
            return;
        }

        IngredientSlots[slot].ItemImage.enabled = true;
        IngredientSlots[slot].ItemImage.sprite = sprite;
        //IngredientSlots[slot].
    }

    public void RemoveFromCraftingMenu(int slot) {
        if (IngredientSlots[slot].InventorySlotReference != null) {
            SetSlotImage(slot, null);
            Items[slot] = null;
            
            
            IngredientSlots[slot].InventorySlotReference.CraftingSlotReference = null;
            IngredientSlots[slot].InventorySlotReference = null;
        }
    }

    public void ShowCombinedItem() {
        // Determine crafted item ID
        int craftedItemID = CraftingRecipies.DetermineCraftingOutcome_V2(Items[0].ID, Items[1].ID);
        Debug.Log(" | " + Items[0].ID + " | " + Items[1].ID + " Grafted aitem aidee: " + craftedItemID);
        // Instantiate item
        // Set held item
        OutcomeSlot.HeldItem = Instantiate(CraftingRecipies.ListOfAllCombinedItems[craftedItemID]);
        Items[2] = OutcomeSlot.HeldItem;
        // Set shown sprite
        OutcomeSlot.ItemSprite = OutcomeSlot.HeldItem.Sprite;
        // Enable image
        OutcomeSlot.ItemImage.enabled = true;
        OutcomeSlot.ItemImage.sprite = OutcomeSlot.ItemSprite;
        // Hide item from view
        OutcomeSlot.HeldItem.gameObject.SetActive(false);
    }

    public void ClearCombinedItem() {
        OutcomeSlot.HeldItem = null;
        Items[2] = null;
        OutcomeSlot.ItemImage.enabled = false;
        OutcomeSlot.ItemSprite = null;
    }

    public void Craft() {
        if (IngredientSlots[0].InventorySlotReference == null || IngredientSlots[1].InventorySlotReference == null) {
            Debug.Log("Not all crafting slots contain an item");
            return;
        }
        Debug.Log("Craft");
        Item craftedItem = OutcomeSlot.HeldItem;
        InventorySlotScript destinationSlot = Inventory.InventorySlots[IngredientSlots[0].InventorySlotReference.slotNumber];
        ClearInventorySlots();
        SendCombinedItemToInventory(craftedItem, destinationSlot);
        //RemoveFromCraftingMenu(0);
        //RemoveFromCraftingMenu(1);
        //if (CraftingRecipies.ID0_0 == IngredientSlots[0].InventorySlotReference.HeldItem.ID) {
        //    Debug.Log("Changing");
        //    OutcomeSlot.ItemImage.enabled = true;
        //} else {
        //    Debug.Log("Not changing");
        //    OutcomeSlot.ItemImage.enabled = false;
        //}
    }

    private void ClearInventorySlots() {
        int firstSlot = IngredientSlots[0].InventorySlotReference.slotNumber;
        int secondSlot = IngredientSlots[1].InventorySlotReference.slotNumber;

        Inventory.RemoveFromInventory(firstSlot, true);
        Inventory.RemoveFromInventory(secondSlot, true);
    }

    private void SendCombinedItemToInventory(Item combinedItem, InventorySlotScript destinationInventorySlot) {
        //Items[2].gameObject.SetActive(true);
        Inventory.AddToInventory(combinedItem, destinationInventorySlot.slotNumber);
    }
}
