using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour {
    public Inventory Inventory;
    private GameObject itemObject;
    private Item item;

    public Text pickUpItemText;

    public KeyCode itemPickupKey = KeyCode.Z;

    private bool itemInRange = false;

    private void Start() {
        if (Inventory == null) {
            Inventory = GetComponent<Inventory>();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(itemPickupKey)) {
            if (itemInRange) {
                PickUp(item.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Item>() == null) {
            Debug.Log("Object does not contain Item component, so it can't be picked up");
            return;
        }
        itemObject = other.gameObject;

        ItemInRange(true, itemObject.GetComponent<Item>());
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Item>() == null) {
            Debug.Log("Object does not contain Item component, so it can't be picked up");
            return;
        }
        itemObject = other.gameObject;
        if (itemObject.GetComponent<Item>() != item) {
            return;
        }

        ItemInRange(false, item);
    }

    public bool ItemInRange(bool _itemInRange, Item _item) {
        item = itemObject.GetComponent<Item>();
        if (_itemInRange) {
            Debug.Log(item + " is in range for pickup.");
            pickUpItemText.text = "Press " + itemPickupKey + " to pick up " + item.ItemName;
            pickUpItemText.enabled = true;
        } else {
            Debug.Log(item + " is no longer in range.");
            pickUpItemText.enabled = false;
        }

        itemInRange = _itemInRange;
        return _itemInRange;
    }

    private void PickUp(GameObject pickup) {

        for (int i = 0; i < Inventory.Items.Length; i++) {
            // Check if inventory is full
            if (i == 3 && Inventory.Items[i] != null) {
                Debug.Log("Inventory is full.");
                pickUpItemText.text = "Inventory full!";
                return;
            } 
            // Check if the current item slot already contains an item
            else if (Inventory.Items[i] != null) {
                //Debug.Log("Slot " + i + " already has an item: " + Inventory.Items[i]);
            }
            // Put an item into the first empty item slot
            else {
                Debug.Log("You put <b>" + item.ItemName + "</b> into slot <b>" + i + "</b>");
                Inventory.Items[i] = pickup.gameObject;
                Inventory.AddToInventory(pickup, i);
                pickup.SetActive(false);
                pickUpItemText.enabled = false;
                ItemInRange(false, item);
                return;
            }
        }
    }
}
// Feedback Vincent:
// string comparison is traag, number comparison is snel
// maak gebruik van item ID's
// maak classes voor items
// class item, functionaliteit die het wel of niet kan doen in json/XML/editor
