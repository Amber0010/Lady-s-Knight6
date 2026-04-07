using UnityEngine;
using System;

public class LadyBugMovementNewAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    public float jumpForce = 2f;
    public float interactRange = 2f;
    public float detectionRange = 2f;

    public float sparkleDur = 0.05f;

    public Rigidbody2D rb;
    bool RightFacing = true;
    private float glideSpeed = -1.5f;
    private float startGravity;

    private Animator animator;
    public SpriteRenderer spriteRenderer;

    public GameObject sparkleSpell;
    public float sparkleDuration = 1f;
    private bool canJump = true;
    public string sparkleInteract = "SparkleInteract";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startGravity = rb.gravityScale;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float move = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            move = -1f;
            RightFacing = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move = 1f;
            RightFacing = true;
        }

        if (move > 0)
        {
            RightFacing = true;
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            RightFacing = false;
            spriteRenderer.flipX = true;
        }

        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", Math.Abs(rb.linearVelocity.y));

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            if (rb.linearVelocityY <= 0)
            {
                rb.gravityScale = startGravity;
            }
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            canJump = false;

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastSparkle();
            animator.SetTrigger("Attack");
        }
        if (Input.GetKey(KeyCode.W) && rb.linearVelocityY <= 0)
        {
            rb.gravityScale = startGravity * .3f;
            //animator.SetBool("isGliding", true);
            rb.linearVelocity = new Vector2(rb.linearVelocityX, glideSpeed);
        }
        else
        {
            rb.gravityScale = startGravity;
            //animator.SetBool("isGliding", false);
        }
    }

    void CastSparkle()
    {
        Vector2 direction = RightFacing ? Vector2.right : Vector2.left;
        Vector2 checkPos = (Vector2)transform.position + direction * detectionRange;
        Collider2D[] hits = Physics2D.OverlapCircleAll(checkPos, interactRange);
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(sparkleInteract))
            {
                float dist = Vector2.Distance(transform.position, hit.transform.position);
                if (dist < closestDistance)
                {
                    closestDistance = dist;
                    closestTarget = hit.transform;
                }
            }
        }
        if (closestTarget != null && sparkleSpell != null)
        {
            GameObject effect = Instantiate(sparkleSpell, transform.position, Quaternion.identity);
            SparkleMagicLogic spell = effect.GetComponent<SparkleMagicLogic>();
            if (spell != null)
            {
                spell.setTarget(closestTarget);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Vector2 direction = RightFacing ? Vector2.right : Vector2.left;
        Vector2 checkPos = (Vector2)transform.position + direction * detectionRange;

        Gizmos.DrawWireSphere(checkPos, interactRange);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > .5f)
        {
            canJump = true;
        }
    }
}
