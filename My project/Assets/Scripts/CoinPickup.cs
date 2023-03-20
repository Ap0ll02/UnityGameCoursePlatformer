using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip myAud;
    int Score;
    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
            AudioSource.PlayClipAtPoint(myAud, cam.main.transform.postion);
            Destroy(gameObject);
        }
    }
}
