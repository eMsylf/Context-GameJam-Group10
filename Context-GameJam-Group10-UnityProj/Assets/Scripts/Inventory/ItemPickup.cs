using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    private Inventory Inventory;
    private GameObject pickup;

    private void Start() {
        Inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Item>() == null) {
            Debug.Log("Object does not contain Item component, so it can't be picked up");
            return;
        }
        pickup = collision.gameObject;
        AddToInventory(pickup);
    }

    private void AddToInventory(GameObject pickup) {
        for (int i = 0; i < Inventory.Items.Length; i++) {
            // Check if inventory is full
            if (i == 3 && Inventory.Items[i] != null) {
                Debug.Log("Inventory is full.");
                return;
            } 
            // Check if the current item slot already contains an item
            else if (Inventory.Items[i] != null) {
                Debug.Log("Slot " + i + " already has an item: " + Inventory.Items[i]);
            }
            // Put an item into the first empty item slot
            else {
                Debug.Log("You put <b>" + pickup.name + "</b> into slot <b>" + i + "</b>");
                Inventory.Items[i] = pickup.gameObject;
                pickup.SetActive(false);
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
