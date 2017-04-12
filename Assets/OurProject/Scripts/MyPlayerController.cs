using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D playerRigidbody;

    private bool playerMoving;
    private Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    
    // Use this for initialization 
    void Start() {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        lastMove = new Vector2(0, -1f);
    }

    // Update is called once per frame 
    void Update() {

        playerMoving = false;

        if (!attacking)
        {
            /*
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                //transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f ) );
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                //transform.Translate (new Vector3 (0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f) );
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
            }
            */

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if(moveInput != Vector2.zero)
            {
                playerRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                playerRigidbody.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                playerRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }

            /*
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }
            */

        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

}﻿
