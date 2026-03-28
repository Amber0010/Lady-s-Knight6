using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SirRoly_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 2f;
    Rigidbody2D rb;

    public bool isRolled = false;

    public GameObject normalState;
    public GameObject rolledState;

    public GameObject sword;
    public Transform swordSpawnLeft;
    public Transform swordSpawnRight;

    private Animator animator;
    
    public bool canJump = true;
    
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.J))
        {
            move = -1f;
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            if (isRolled)
            {
                rb.AddForce(Vector2.left * .5f, ForceMode2D.Force);
            }
        }
        else if (Input.GetKey(KeyCode.L))
        {
            move = 1f;
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            if (isRolled)
            {
                rb.AddForce(Vector2.right * .5f, ForceMode2D.Force);
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        if (move > 0)
        {
            facingRight = true;
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            facingRight = false;
            spriteRenderer.flipX = true;
        }

        animator.SetBool("isWalking", move != 0);

        if (Input.GetKeyDown(KeyCode.I) && canJump && !isRolled)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            changeState();
            rolyState();
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.O) && !isRolled)
        {
            SpawnSword();
        }
    } 
    public bool IsRolled()
    {
        return isRolled;
    }

    void changeState()
    {
        isRolled = !isRolled;
    }

    public void rolyState()
    {
        if (!isRolled)
        {
            normalState.transform.position = rolledState.transform.position;
            normalState.SetActive(true);
            rolledState.SetActive(false);
        }
        if (isRolled)
        {
            rolledState.transform.position = normalState.transform.position;
            normalState.SetActive(false);
            rolledState.SetActive(true);
        }
    }

    void SpawnSword()
    {
        if (sword == null) return;

        GameObject swordObj;

        if (facingRight)
        {
             swordObj = Instantiate(sword, swordSpawnRight.position, swordSpawnRight.rotation, swordSpawnRight);
        }
        if (!facingRight)
        {
            swordObj = Instantiate(sword, swordSpawnLeft.position, swordSpawnLeft.rotation, swordSpawnLeft);
        }
        else
        {
            swordObj = Instantiate(sword, swordSpawnRight.position, swordSpawnRight.rotation, swordSpawnRight);
        }

        Sword swing = swordObj.GetComponent<Sword>();

        if (swing != null)
        {
            swing.Init(facingRight);
        }
    }

    private void Reset()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

}


