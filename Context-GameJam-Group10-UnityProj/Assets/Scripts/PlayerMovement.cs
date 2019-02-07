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

    private Rigidbody rb;

    private PositionReset PositionReset;

    private KeyCode PositionResetButton;
    public Vector3 resetCoordinates = new Vector3(0, 0, 0);

    private TrailRenderer ChildTrail;
    private ParticleSystem ChildParticles;

    public ForceMode ForceModePlayer;

    private bool isMoving = false;

    private void Awake() {
        ChildTrail = gameObject.GetComponentInChildren<TrailRenderer>();
        ChildParticles = ChildTrail.GetComponentInChildren<ParticleSystem>();
        PlayerSpriteAnimatorObject = gameObject.GetComponentInChildren<PlayerSprite>().gameObject;
        PlayerSpriteAnimator = PlayerSpriteAnimatorObject.GetComponent<Animator>();
    }

    void Start() {
        PositionReset = gameObject.GetComponent<PositionReset>();
        PositionResetButton = PositionReset.ResetButton;

        

        rb = GetComponent<Rigidbody>();
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

            ChildTrail.emitting = true;
            ChildParticles.Play();

            //gameObject.transform.GetChild(0).gameObject.SetActive(true);

        } else {
            runSpeedMultiplier = 1;

            ChildTrail.emitting = false;
            ChildParticles.Stop();
            
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        //rb.AddForce(movement * speed * runSpeedMultiplier * diagonalSpeedMultiplier * dashSpeedMultiplier, ForceModePlayer);

        rb.position += (movement * speed * runSpeedMultiplier * diagonalSpeedMultiplier * dashSpeedMultiplier);

        ResetPosition();

        PlayerSpriteAnimator.SetBool("IsMoving", isMoving);
    }

    public void ResetPosition() {
        if (Input.GetKeyDown(PositionResetButton)) gameObject.transform.position = resetCoordinates;
    }
}