//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
    private bool isColliding = false;
    private GameObject collidingObject;
    public GameObject DialogueUI;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Interactable>() == null) {
            return;
        }
        collidingObject = collision.gameObject;
        IsColliding(true);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Interactable>() == null) {
            return;
        }//is het netjes om hier een else {} te gebruiken?
        IsColliding(false);

        collidingObject = collision.gameObject;
    }

    public bool IsColliding(bool t_isColliding) { //wat is er met de naming convention m_Variable? waarom m_?
        collidingObject.GetComponent<SpriteRenderer>().enabled = !t_isColliding;

        Debug.Log(name + " is colliding with " + collidingObject.name + " " + t_isColliding);
        if (DialogueUI == null) {
            return true;
        }
        DialogueUI.SetActive(t_isColliding);
        isColliding = t_isColliding;
        return t_isColliding;
    }

    private void InteractWithObject() {
        Debug.Log(name + "I am trying to interact with " + collidingObject.name);
    }

    void Update() {
        //Debug.Log("Player is colliding: " + isColliding);
        if (isColliding && Input.GetKeyDown(KeyCode.Space)) {
            InteractWithObject();
        }
    }
}
