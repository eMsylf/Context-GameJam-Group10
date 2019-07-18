//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
    private bool isColliding = false;
    private GameObject collidingObject;
    public GameObject DialogueUI;

    private Inventory Inventory;

    public bool useUIForTesting;

    private void OnTriggerEnter2D(Collider2D collision) {
        collidingObject = collision.gameObject;

        if (collidingObject.GetComponent<Item>() != null) {
            Item item = collidingObject.GetComponent<Item>();
            ItemInRange(true, item);
        }

        AddToInventory(collidingObject.GetComponent<Item>());
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Item>() == null) {
            return;
        }//is het netjes om hier een else {} te gebruiken?
        Item item = collision.gameObject.GetComponent<Item>();
        ItemInRange(false, item);
    }

    public bool ItemInRange(bool _itemInRange, Item _item) { //wat is er met de naming convention m_Variable? waarom m_?
        collidingObject.GetComponent<SpriteRenderer>().enabled = !_itemInRange;

        Debug.Log(name + " is colliding with " + collidingObject.name + " " + _itemInRange);
        if (DialogueUI == null) {
            return true;
        }
        DialogueUI.SetActive(_itemInRange);
        isColliding = _itemInRange;
        return _itemInRange;
    }

    private void InteractWithObject() {
        Debug.Log(name + ": I am trying to interact with " + collidingObject.name);
    }

    private void AddToInventory(Item m_item) {
        //Inventory.Interactables.Add(m_item);
        Debug.Log("Adding item: " + m_item.ItemName);
    }

    void Update() {
        //Debug.Log("Player is colliding: " + isColliding);
        if (isColliding && Input.GetKeyDown(KeyCode.Z)) {
            InteractWithObject();
            AddToInventory(collidingObject.GetComponent<Item>());
        }
    }
}
