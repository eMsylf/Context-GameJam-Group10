using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    private float runSpeedMultiplier = 1.0f;
    public float runSpeedMultiplierHigh = 2.0f;
    private float diagonalSpeedMultiplier = 1.0f;
    //private float dashSpeedMultiplier = 1.0f;

    private GameObject PlayerSpriteAnimatorObject;
    private Animator PlayerSpriteAnimator;

    float moveHorizontal;
    float moveVertical;

    public Rigidbody rb;

    private TrailRenderer ChildTrail;
    private ParticleSystem ChildParticles;

    public ForceMode ForceModePlayer;

    private bool isMoving = false;
    private bool movingUp = false;
    private bool movingDown = false;
    private bool movingLeft = false;
    private bool movingRight = false;

    public float jumpForce = 1f;
    private bool isStanding = false;

    private Camera cam;

    public Interactable_Brackeys focus;

    private void Awake() {
        ChildParticles = GetComponentInChildren<ParticleSystem>();
        PlayerSpriteAnimatorObject = gameObject.GetComponentInChildren<PlayerSprite>().gameObject;
        PlayerSpriteAnimator = PlayerSpriteAnimatorObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Start() {

    }

    void Update() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0) {
            diagonalSpeedMultiplier = 1.0f;
        } else diagonalSpeedMultiplier = 1.4f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (Input.GetKey(KeyCode.LeftShift) && isMoving) {
            runSpeedMultiplier = runSpeedMultiplierHigh;

            ChildParticles.Play();


        } else {
            runSpeedMultiplier = 1;

            ChildParticles.Stop();

        }

        if (Input.GetKeyDown(KeyCode.Space) && isStanding) {
            Jump();
        }

        rb.position += (movement * speed * runSpeedMultiplier * diagonalSpeedMultiplier * Time.deltaTime);
        
        DetermineDirection();
        PlayerSpriteAnimator.SetBool("MovingUp", movingUp);
        PlayerSpriteAnimator.SetBool("MovingDown", movingDown);
        PlayerSpriteAnimator.SetBool("MovingLeft", movingLeft);
        PlayerSpriteAnimator.SetBool("MovingRight", movingRight);

        //if (Input.GetMouseButton(0)) {
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if ()
        //}

        //if (Input.GetMouseButtonDown(1)) {
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100)) {
        //        Interactable_Brackeys interactable = hit.collider.GetComponent<Interactable_Brackeys>();
        //        if (interactable != null) {
        //            SetFocus(interactable);
        //        }
        //    }
        //}

    }

    //private void SetFocus(Interactable_Brackeys newFocus) {
    //    focus = newFocus;
    //}

    private void DetermineDirection() {
        if (Input.GetAxis("Vertical") > 0) {
            movingUp = true;

        } else movingUp = false;

        if (Input.GetAxis("Vertical") < 0) {
            movingDown = true;

        } else movingDown = false;

        if (Input.GetAxis("Horizontal") < 0) {
            movingLeft = true;

        } else movingLeft = false;

        if (Input.GetAxis("Horizontal") > 0) {
            movingRight = true;

        } else movingRight = false;
    }

    private void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "polySurface4") {
            isStanding = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "polySurface4") {
            isStanding = false;
        }
    }
}