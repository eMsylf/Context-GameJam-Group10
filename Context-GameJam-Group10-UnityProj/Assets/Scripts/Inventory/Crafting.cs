using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {
    public Inventory Inventory;
    public GameObject[] IngredientSlots;
    public GameObject Outcome;
    public GameObject[] Items;

    void Start() {

    }

    void Update() {

    }

    public void AddToCrafting() {

    }

    public void AddToCrafting(int slot) {
        GameObject currentSlot = IngredientSlots[slot];
        Image currentSlotImage = currentSlot.GetComponent<InventorySlotScript>().ItemImage;
        Button currentSlotRemoveButton = currentSlot.GetComponent<InventorySlotScript>().ItemRemoveButton;
        //Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;

        currentSlotImage.enabled = true;
        //currentSlotImage.sprite = item.GetComponent<SpriteRenderer>().sprite;

        currentSlotRemoveButton.interactable = true;
    }
}
