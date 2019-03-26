using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform GUITarget;

    
    void Update()
    {
        transform.LookAt(GUITarget);
    }
}
