//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {
    private bool v_isColliding = false;
    private GameObject collidingObject;
    public GameObject DialogueUI;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Interactable>() == null) {
            return;
        }
        collidingObject = collision.gameObject;
        isColliding(true);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Interactable>() == null) {
            return;
        }
        isColliding(false);

        collidingObject = null;
    }

    public bool isColliding(bool m_isColliding) {
        collidingObject.GetComponent<SpriteRenderer>().enabled = !m_isColliding;

        Debug.Log(collidingObject.name + " " + m_isColliding);
        if (DialogueUI == null) {
            return true;
        }
        DialogueUI.SetActive(m_isColliding);
        v_isColliding = m_isColliding;
        return m_isColliding;
    }

    //private void CollidingWithObject(bool m_isColliding) {
    //    collidingObject.GetComponent<SpriteRenderer>().enabled = !m_isColliding;
        
    //    Debug.Log(collidingObject.name + " " + m_isColliding);
    //    if (DialogueUI == null) {
    //        return;
    //    }
    //    DialogueUI.SetActive(true);
    //}

    private void InteractWithObject() {
        Debug.Log("I am trying to interact with " + collidingObject.name);
    }

    void Update() {
        Debug.Log("Player is colliding: " + v_isColliding);
        if (v_isColliding && Input.GetKeyDown(KeyCode.Space)) {
            InteractWithObject();
        }
    }
}
