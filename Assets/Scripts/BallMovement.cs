using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    private float velocity;
    private Rigidbody2D ball;
    private GameObject player;
    private GameObject scoreText;
    public int score;
    
    AudioSource wallHit;
    AudioSource paddleHit;
    AudioSource miss;
    
    void Awake() {
        player = GameObject.Find("Player");
        ball = GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("Score");
        
        AudioSource[] audioSources = GetComponents<AudioSource>();
        wallHit = audioSources[0];
        paddleHit = audioSources[1];
        miss = audioSources[2];
    }
    
    void Start() {
        float pos_x = player.GetComponent<Transform>().position.x;
        float pos_y = player.GetComponent<Transform>().position.y + player.GetComponent<Transform>().localScale.y/2 + transform.localScale.y/2;
        
        transform.position = Vector2.Lerp(transform.position, new Vector2(pos_x, pos_y + 0.02f), 1);
        
        float limit_x;
        do {
            limit_x = Random.Range(-1.0f, 1.0f);
        } while (limit_x > -0.3f && limit_x < 0.3f);
        float limit_y = 1;
        
        Vector2 randomVector = new Vector2(limit_x, limit_y);
        ball.AddRelativeForce(randomVector * 150);
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.name != "Player") {
            wallHit.Play();
            return;
        }
        
        if (ball.velocity.x > 25.0f || ball.velocity.y > 25.0f) {
            return;
        }
            
        ball.AddForce(ball.velocity.normalized * 1.1f, ForceMode2D.Impulse);
        paddleHit.Play();
        
        score++;
        scoreText.GetComponent<Text>().text = score.ToString();
    }
    
    void OnGUI() {
        if (transform.position.y < player.GetComponent<Transform>().position.y) {
            miss.Play();
            SceneManager.LoadScene(0);
        }
    }
}
