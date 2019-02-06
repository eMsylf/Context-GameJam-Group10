using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWriterSound : MonoBehaviour
{
    public AudioSource TypeWriterSFX;

    public void PlaySound() {
        TypeWriterSFX.Play();
    }

    public void PauseSound() {
        TypeWriterSFX.Stop();
    }
}
