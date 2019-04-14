using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    private Vector3 mousePosition;
    
    public GameObject leftWall;
    public GameObject rightWall;
    
    void Awake() {
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");
    }
    
    void OnGUI() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = transform.position.y;
        
        var newPosition = transform.position;
        
        // Touching left wall
        if (transform.position.x - transform.localScale.x/2 < leftWall.GetComponent<Transform>().position.x + leftWall.GetComponent<Transform>().localScale.x/2) {
            newPosition.x = leftWall.GetComponent<Transform>().position.x + leftWall.GetComponent<Transform>().localScale.x/2 + transform.localScale.x/2;
            
        // Touching right wall
        } else if (transform.position.x + transform.localScale.x/2 > rightWall.GetComponent<Transform>().position.x - rightWall.GetComponent<Transform>().localScale.x/2) {
            newPosition.x = rightWall.GetComponent<Transform>().position.x - rightWall.GetComponent<Transform>().localScale.x/2 - transform.localScale.x/2;
            
        // Not touching wall
        } else {
            newPosition.x = mousePosition.x;
        }
        
        transform.position = newPosition;
    }
}
