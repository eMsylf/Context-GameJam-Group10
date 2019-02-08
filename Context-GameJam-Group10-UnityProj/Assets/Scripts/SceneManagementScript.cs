using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public AudioSource StartGameSound;
    public AudioSource Music;

    public void StartGame() {
        StartGameSound.Play();
        Music.Stop();
        StartCoroutine("enumerator");
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator enumerator () {
        yield return new WaitForSeconds(2.5f);
        NextScene();
    }
}
