using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] Animator pAnim;
    [SerializeField] float jumpSpeed = 7f;
    CapsuleCollider2D pColl;
    [SerializeField] float climbSpeed = 5f;
    BoxCollider2D pBColl;
    float playerGravAtStart;
    bool isAlive = true;
    [SerializeField] TilemapCollider2D tmCollider;
    [SerializeField] GameObject mc;
    [SerializeField] GameObject fireball;
    [SerializeField] Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        pColl = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        pAnim = GetComponent<Animator>();
        playerGravAtStart = rb.gravityScale;
        pBColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive){
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        OnHit();
    }

    void OnFire(InputValue value){
        if(!isAlive){return;}
        Instantiate(fireball, gun.position, transform.rotation);
    }

    void OnMove(InputValue value){
        if(!isAlive){
            return;
        }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        if(!isAlive){
            return;
        }
        if(!pBColl.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return; 
        }
        if(value.isPressed){
            rb.velocity += new Vector2 (0f, jumpSpeed);
        }
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

    void ClimbLadder(){
        if(!pBColl.IsTouchingLayers(LayerMask.GetMask("Climbing"))){
            rb.gravityScale = playerGravAtStart;
            pAnim.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2 (rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;

        if(Mathf.Abs(rb.velocity.y) > Mathf.Epsilon && !pColl.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            pAnim.SetBool("isClimbing", true);
        } else pAnim.SetBool("isClimbing", false);
    }

    void OnHit(){
        if(pColl.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) || transform.position.y < -6){
            isAlive = false;
            pAnim.SetTrigger("Dead");
            tmCollider.enabled = false;
            mc.SetActive(false);
        }
    }
}
