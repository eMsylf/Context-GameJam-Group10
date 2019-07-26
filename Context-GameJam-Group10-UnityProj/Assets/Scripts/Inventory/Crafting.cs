using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {
    public Inventory Inventory;
    public CraftingSlotScript[] IngredientSlots;
    public GameObject Outcome;
    public Item[] Items;
    private Image IngredientSlotImage;

    private void Start() {
        ResetSlotImages();
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

    public void Craft() {
        //Items[3] = 
    }
}
