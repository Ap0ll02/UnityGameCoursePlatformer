using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] Animator pAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void Run(){
        Vector2 playerVelocity = new Vector2 (playerSpeed*moveInput.x, rb.velocity.y);
        rb.velocity = playerVelocity;
        if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon){
            pAnim.SetBool("isRunning", true);
        }else pAnim.SetBool("isRunning", false);

    }

    void FlipSprite(){
        bool playerMovin = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(playerMovin){
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
        }
        
    }
}
