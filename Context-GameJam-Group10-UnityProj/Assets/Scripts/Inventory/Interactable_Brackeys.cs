using UnityEngine;

public class Interactable_Brackeys : MonoBehaviour {
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform playerTransform;

    private bool hasInteracted = false;

    private void Start() {
        interactionTransform = GetComponentInChildren<InteractionTransform>().transform;
    }

    public virtual void Interact () {
        // This method is meant to be overwritten
        Debug.Log("Interacting with" + transform.name);
    }

    private void Update() {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(playerTransform.position, interactionTransform.position);
            if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused (Transform m_playerTransform) {
        isFocus = true;
        playerTransform = m_playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused () {
        isFocus = false;
        playerTransform = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
