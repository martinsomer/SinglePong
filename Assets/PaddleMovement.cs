using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    private Vector3 mousePosition;
    private float moveSpeed = 1f;
    
    // Update is called once per frame
    void Update() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.y = transform.position.y;
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
