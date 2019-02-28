using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWriterSound : MonoBehaviour
{
    public AudioSource TypeWriterSFX;

    public void PlaySound() {
        if (TypeWriterSFX == null) {
            return;
        }
        TypeWriterSFX.Play();
    }

    public void PauseSound() {
        if (TypeWriterSFX == null) {
            return;
        }
        TypeWriterSFX.Stop();
    }
}
