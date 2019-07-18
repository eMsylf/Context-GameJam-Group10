using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToggleOtherObjectWithButton : MonoBehaviour {

    public GameObject Object;
    public bool ObjectEnabled;

    public KeyCode key;

    private bool toggle_enabled;

    void Awake() {
        toggle_enabled = ObjectEnabled;
        Object.SetActive(toggle_enabled);
    }

    private void OnValidate() {
        toggle_enabled = ObjectEnabled;
        Object.SetActive(toggle_enabled);
    }

    public void ToggleObject(GameObject gameObject) {
        toggle_enabled = !toggle_enabled;
        gameObject.SetActive(toggle_enabled);
    }

    void Update() {
        if (Input.GetKeyDown(key)) {
            ToggleObject(Object);
        }
    }
}
