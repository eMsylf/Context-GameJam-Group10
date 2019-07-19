using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Crafting Crafting;
    public GameObject[] InventorySlots;
    public GameObject[] Items;
    public Transform Player;

    private void Awake() {
        
    }

    private void Update() {
        
    }

    public void AddToInventory(GameObject item, int slot) {
        GameObject currentSlot = InventorySlots[slot];
        Image currentSlotImage = currentSlot.GetComponent<InventorySlotScript>().ItemImage;
        Button currentSlotRemoveButton = currentSlot.GetComponent<InventorySlotScript>().ItemRemoveButton;
        Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;

        currentSlotImage.enabled = true;
        currentSlotImage.sprite = item.GetComponent<SpriteRenderer>().sprite;

        currentSlotRemoveButton.interactable = true;
    }

    public void RemoveFromInventory(int slot) {
        GameObject item = Items[slot];
        item.SetActive(true);
        item.transform.position = Player.position;
        Items[slot] = null;

        GameObject currentSlot = InventorySlots[slot];

        currentSlot.GetComponent<InventorySlotScript>().ItemImage.enabled = false;
        currentSlot.GetComponent<InventorySlotScript>().ItemRemoveButton.interactable = false;

        Debug.Log("Dropping item");
    }
}
