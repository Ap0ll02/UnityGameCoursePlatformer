using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    int score;
    bool wasC = false;
    [SerializeField] AudioClip myAud;
    //[SerializeField] GameObject cam;
    [SerializeField] int pointsToAdd = 1000;
    private void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !wasC)
        {
            wasC = true;
            FindObjectOfType<GameSession>().AddScore(pointsToAdd);
            AudioSource.PlayClipAtPoint(myAud, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
