using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {
    
    private AudioSource buttonAudio;
    private IEnumerator coroutine;
    
    void Awake() {
        buttonAudio = GetComponent<AudioSource>();
    }
    
    public void loadScene(int scene) {
        StartCoroutine(load(scene));
    }
    
    private IEnumerator load(int scene) {
        buttonAudio.Play();
        yield return new WaitForSeconds(buttonAudio.clip.length);
        SceneManager.LoadScene(scene);
    }
    
    public void quitGame() {
        StartCoroutine(quit());
    }
    
    private IEnumerator quit() {
        buttonAudio.Play();
        yield return new WaitForSeconds(buttonAudio.clip.length);
        Application.Quit();
    }
}
