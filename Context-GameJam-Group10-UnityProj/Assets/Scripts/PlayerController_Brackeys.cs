using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Brackeys : MonoBehaviour {

    public Interactable_Brackeys focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor_Brackeys playerMotor_Brackeys;

    void Start() {
        cam = Camera.main;
        playerMotor_Brackeys = GetComponent<PlayerMotor_Brackeys>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                // Move our player to what we hit
                playerMotor_Brackeys.MoveToPoint(hit.point);

                // Stop focusing any objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                // Check if we hit an interactable
                Interactable_Brackeys interactable_Brackeys = hit.collider.GetComponent<Interactable_Brackeys>();
                if (interactable_Brackeys != null) {
                    SetFocus(interactable_Brackeys);
                }
                // If we did, set it as our focus
            }
        }
    }

    private void SetFocus(Interactable_Brackeys newFocus) {
        if (newFocus != focus) {
            if (focus != null) {
                focus.OnDefocused();
            }
            focus = newFocus;
            playerMotor_Brackeys.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus() {
        if (focus != null) {
            focus.OnDefocused();
        }
        focus = null;
        playerMotor_Brackeys.StopFollowingTarget();
    }
}
