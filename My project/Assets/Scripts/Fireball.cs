using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement player;
    [SerializeField] float fSpeed = 17f;
    float xSpeed;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * fSpeed;
    }

    private void Update() {
        rb.velocity = new Vector2 (xSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
