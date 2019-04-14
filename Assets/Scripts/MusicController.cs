using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    public static AudioSource music;
    
    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        music = audioSources[Random.Range(0, audioSources.Length - 1)];
    }
}
