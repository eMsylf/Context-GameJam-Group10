using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    public KeyCode ResetButton;
    public Vector3 resetCoordinates = new Vector3(0, 0, 0);

    public void ResetPosition () {
        if (Input.GetKeyDown(ResetButton)) gameObject.transform.position = resetCoordinates;
    }
}
