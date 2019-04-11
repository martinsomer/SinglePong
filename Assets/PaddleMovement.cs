using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    private Vector3 mousePosition;
    private float moveSpeed = 1f;
    
    public GameObject leftWall;
    public GameObject rightWall;
    
    void Awake() {
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");
    }
    
    // Update is called for rendering and handling GUI events
    void OnGUI() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.y = transform.position.y;
        
        // Touching left wall
        if ((transform.position.x - transform.localScale.x/2) < (leftWall.GetComponent<Transform>().position.x + leftWall.GetComponent<Transform>().localScale.x/2)) {
            transform.position = Vector2.Lerp(transform.position, new Vector2(((leftWall.GetComponent<Transform>().position.x + leftWall.GetComponent<Transform>().localScale.x/2) + transform.localScale.x/2), transform.position.y), moveSpeed);
            return;
        }
        
        // Touching right wall
        if (transform.position.x + transform.localScale.x/2 > rightWall.GetComponent<Transform>().position.x - rightWall.GetComponent<Transform>().localScale.x/2) {
            transform.position = Vector2.Lerp(transform.position, new Vector2(((rightWall.GetComponent<Transform>().position.x - rightWall.GetComponent<Transform>().localScale.x/2) - transform.localScale.x/2), transform.position.y), moveSpeed);
            return;
        }
        
        // Not touching wall
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
