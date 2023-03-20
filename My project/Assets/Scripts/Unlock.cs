using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField] Animator button;
    [SerializeField] GameObject lockDoor;
    // Start is called before the first frame update
    private void Start() {
        button = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
        button.SetTrigger("Pressed");
        lockDoor.SetActive(false);
        }
    }
}
