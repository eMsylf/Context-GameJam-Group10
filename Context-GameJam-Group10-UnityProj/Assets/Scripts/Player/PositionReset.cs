using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour {
    public KeyCode ResetButton;
    public Vector3 resetCoordinates;

    public void ResetPosition() {
        if (Input.GetKeyDown(ResetButton)) {
            gameObject.transform.position = resetCoordinates;
        }
        Debug.Log("Resetting coordinates to " + resetCoordinates);
    }
}
