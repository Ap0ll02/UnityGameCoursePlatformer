using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip myAud;
    //[SerializeField] GameObject cam;
    int Score;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            AudioSource.PlayClipAtPoint(myAud, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
