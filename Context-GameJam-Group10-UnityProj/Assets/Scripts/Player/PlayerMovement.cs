using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    private float runSpeedMultiplier = 1.0f;
    public float runSpeedMultiplierHigh = 2.0f;
    private float diagonalSpeedMultiplier = 1.0f;
    private float dashSpeedMultiplier = 1.0f;

    private GameObject PlayerSpriteAnimatorObject;
    private Animator PlayerSpriteAnimator;

    float moveHorizontal;
    float moveVertical;

    public Rigidbody rb;

    private PositionReset PositionReset;

    private KeyCode PositionResetButton;
    public Vector3 resetCoordinates = new Vector3(0, 0, 0);

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

    private void Awake() {
        //ChildTrail = gameObject.GetComponentInChildren<TrailRenderer>();
        ChildParticles = GetComponentInChildren<ParticleSystem>();
        //PlayerSpriteAnimatorObject = gameObject.GetComponentInChildren<PlayerSprite>().gameObject;
        //PlayerSpriteAnimator = PlayerSpriteAnimatorObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        PositionReset = gameObject.GetComponent<PositionReset>();
        PositionResetButton = PositionReset.ResetButton;

    }

    void FixedUpdate() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0) {
            diagonalSpeedMultiplier = 1.0f;
        } else diagonalSpeedMultiplier = 1.4f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (Input.GetKey(KeyCode.LeftShift) && isMoving) {
            runSpeedMultiplier = runSpeedMultiplierHigh;

            //ChildTrail.emitting = true;
            ChildParticles.Play();

            //gameObject.transform.GetChild(0).gameObject.SetActive(true);

        } else {
            runSpeedMultiplier = 1;

            //ChildTrail.emitting = false;
            ChildParticles.Stop();

            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isStanding) {
            Jump();
        }

        //rb.AddForce(movement * speed * runSpeedMultiplier * diagonalSpeedMultiplier * dashSpeedMultiplier, ForceModePlayer);

        rb.position += (movement * speed * runSpeedMultiplier * diagonalSpeedMultiplier * Time.deltaTime);
        ResetPosition();
        /*
        DetermineDirection();
        PlayerSpriteAnimator.SetBool("MovingUp", movingUp);
        PlayerSpriteAnimator.SetBool("MovingDown", movingDown);
        PlayerSpriteAnimator.SetBool("MovingLeft", movingLeft);
        PlayerSpriteAnimator.SetBool("MovingRight", movingRight);
        
        PlayerSpriteAnimator.SetBool("IsMoving", isMoving);
        */
    }

    public void ResetPosition() {
        if (Input.GetKeyDown(PositionResetButton)) gameObject.transform.position = resetCoordinates;
    }

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

    private void IsStanding() {

    }
}