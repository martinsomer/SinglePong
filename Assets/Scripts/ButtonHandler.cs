using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {
    
    private AudioSource select;
    private IEnumerator coroutine;
    
    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        select = audioSources[0];
    }
    
    public void loadScene(int scene) {
        StartCoroutine(load(scene));
    }
    
    private IEnumerator load(int scene) {
        select.Play();
        yield return new WaitForSeconds(select.clip.length);
        SceneManager.LoadScene(scene);
    }
    
    public void quitGame() {
        StartCoroutine(quit());
    }
    
    private IEnumerator quit() {
        select.Play();
        yield return new WaitForSeconds(select.clip.length);
        Application.Quit();
    }
}
