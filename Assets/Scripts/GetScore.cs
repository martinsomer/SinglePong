using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {
    
    void Awake() {
        GetComponent<Text>().text += BallMovement.score.ToString();
    }
}
