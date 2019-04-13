using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    private Rigidbody2D ball;
    private GameObject player;
    private GameObject scoreText;
    private IEnumerator coroutine;
    
    private AudioSource wallHit;
    private AudioSource paddleHit;
    private AudioSource miss;
    
    public static int score;
    
    void Awake() {
        score = 0;
        
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
        if (transform.position.y < -5.0f) {
            StartCoroutine(gameOver());
        }
    }
    
    private IEnumerator gameOver() {
        GetComponent<MeshRenderer>().enabled = false;
        transform.position = new Vector2(0, 0);
        ball.velocity = Vector2.zero;
        miss.Play();
        yield return new WaitForSeconds(miss.clip.length);
        SceneManager.LoadScene(2);
    }
}
