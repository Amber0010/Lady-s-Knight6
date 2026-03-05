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
    public Transform swordSpawn;

    private Animator animator;

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
        float move = Input.GetAxisRaw("Horizontal_Roly");

        if (Input.GetKey(KeyCode.J))
        {
            rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
            //transform.position -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.L))
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
            //transform.position += transform.right * Time.deltaTime * speed;
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            changeState();
            rolyState();
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.O))
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

        GameObject swordObj = Instantiate(sword, swordSpawn.position, swordSpawn.rotation, swordSpawn);

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