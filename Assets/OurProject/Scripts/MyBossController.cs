using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBossController : MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D bossRigidbody;

    private bool bossMoving;
    private Vector2 lastMove;
    private Vector2 moveInput;

    private static bool bossExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    // Use this for initialization 
    void Start()
    {
        anim = GetComponent<Animator>();
        bossRigidbody = GetComponent<Rigidbody2D>();

        if (!bossExists)
        {
            bossExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        lastMove = new Vector2(0, -1f);
    }

    // Update is called once per frame 
    void Update()
    {

        bossMoving = false;

        if (!attacking)
        {

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (moveInput != Vector2.zero)
            {
                bossRigidbody.velocity = new Vector2(-moveInput.x * moveSpeed, -moveInput.y * moveSpeed);
                bossMoving = true;
                lastMove = moveInput;
            }
            else
            {
                bossRigidbody.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                bossRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }

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
        anim.SetBool("PlayerMoving", bossMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
