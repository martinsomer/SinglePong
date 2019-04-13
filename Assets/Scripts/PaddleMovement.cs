﻿using System.Collections;
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
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.y = transform.position.y;
        
        // Touching left wall
        if (transform.position.x - transform.localScale.x/2 < leftWall.GetComponent<Transform>().position.x + leftWall.GetComponent<Transform>().localScale.x/2) {
            
            float pos_x = leftWall.GetComponent<Transform>().position.x + leftWall.GetComponent<Transform>().localScale.x/2 + transform.localScale.x/2;
            float pos_y = transform.position.y;
            
            transform.position = new Vector2(pos_x, pos_y);
            return;
        }
        
        // Touching right wall
        if (transform.position.x + transform.localScale.x/2 > rightWall.GetComponent<Transform>().position.x - rightWall.GetComponent<Transform>().localScale.x/2) {

            float pos_x = rightWall.GetComponent<Transform>().position.x - rightWall.GetComponent<Transform>().localScale.x/2 - transform.localScale.x/2;
            float pos_y = transform.position.y;
            
            transform.position = new Vector2(pos_x, pos_y);
            return;
        }
        
        // Not touching wall
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }
}
