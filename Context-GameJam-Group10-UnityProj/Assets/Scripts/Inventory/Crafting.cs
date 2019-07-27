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
        // Instantiate item

        // Set held item
        OutcomeSlot.HeldItem = Instantiate(CraftingRecipies.ListOfAllCombinedItems[CraftingRecipies.DetermineCraftingOutcome_V2(Items[0].ID, Items[1].ID)]);
        OutcomeSlot.HeldItem.gameObject.SetActive(false);
        // Enable image
        OutcomeSlot.ItemImage.enabled = true;
        // Set shown sprite
        OutcomeSlot.ItemSprite = OutcomeSlot.HeldItem.GetComponent<SpriteRenderer>().sprite;
    }

    public void ClearCombinedItem() {
        OutcomeSlot.HeldItem = null;
        OutcomeSlot.ItemImage.enabled = false;
        OutcomeSlot.ItemSprite = null;
    }

    public void Craft() {
        Debug.Log("Craft");
        SendCombinedItemToInventory();
        ClearCombinedItem();
        ClearInventorySlots();
        RemoveFromCraftingMenu(0);
        RemoveFromCraftingMenu(1);
        //if (IngredientSlots[0].InventorySlotReference == null || IngredientSlots[1].InventorySlotReference == null) {
        //    Debug.Log("huh");
        //    return;
        //}
        //if (CraftingRecipies.ID0_0 == IngredientSlots[0].InventorySlotReference.HeldItem.ID) {
        //    Debug.Log("Changing");
        //    OutcomeSlot.ItemImage.enabled = true;
        //} else {
        //    Debug.Log("Not changing");
        //    OutcomeSlot.ItemImage.enabled = false;
        //}
    }

    private void ClearInventorySlots() {
        IngredientSlots[0].InventorySlotReference.HeldItem = null;
        IngredientSlots[1].InventorySlotReference.HeldItem = null;
    }

    private void SendCombinedItemToInventory() {
        
        //throw new NotImplementedException();
    }
}
