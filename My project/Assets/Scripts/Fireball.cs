using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement player;
    [SerializeField] float fSpeed = 7f;
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
        if (other.tag == "Enemy" && FindObjectOfType<EnemyMOvement>().eHealth > 0)
        {
            FindObjectOfType<EnemyMOvement>().eHealth -= 1;

        }
        else if(other.CompareTag("Enemy") && FindObjectOfType<EnemyMOvement>().eHealth < 1) { GameObject.Destroy(other.gameObject); }

        if(other.tag == "OOB"){
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
