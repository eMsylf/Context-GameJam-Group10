using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVertical : MonoBehaviour {
    public float speed = 10.0f;
    public ForceMode ForceModePlayer;

    private Vector2 movement;
    private Rigidbody2D rigidbody2D_player;
    private float moveHorizontal;
    private float moveVertical;
    private float runSpeedMultiplier = 1.5f;

    private void Start() {
        rigidbody2D_player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical); // moet dit per se met een new? Is dat niet onnodig geheugen gebruik?

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            rigidbody2D_player.position += (movement * speed * runSpeedMultiplier * Time.deltaTime);
        } else {
            rigidbody2D_player.position += (movement * speed * Time.deltaTime);
        }
//        Debug.Log(moveHorizontal);
//        Debug.Log(moveVertical);
    }
}
