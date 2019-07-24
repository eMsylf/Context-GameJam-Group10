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

        currentSlotScript.ItemImage.enabled = false;
        currentSlotScript.GetComponent<InventorySlotScript>().ItemRemoveButton.interactable = false;

        Debug.Log("Dropping item");
    }
}
