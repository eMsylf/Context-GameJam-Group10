using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform GUITarget;

    private void Start() {
        GUITarget = FindObjectOfType<Camera>().transform;
    }

    void Update()
    {
        transform.LookAt(GUITarget);
    }
}
