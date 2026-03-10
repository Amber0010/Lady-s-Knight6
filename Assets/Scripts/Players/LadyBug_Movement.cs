
using Unity.VisualScripting;
using UnityEngine;

public class LadyBug_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 2f;
    public float interactRange = 2f;
    public float detectionRange = 2f;


    Rigidbody2D rb;
      bool RightFacing = true;
    public GameObject SparkleMagic;
    private float glideSpeed;
    private float startGravity;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public GameObject sparkleSpell;
    public float sparkleDuration = .5f;

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

        animator.SetBool("isWalking", move != 0);

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");

            if (rb.linearVelocityY <= 0)
            {
                rb.gravityScale = 0;
                animator.SetBool("isGliding", true);
                rb.linearVelocity = new Vector2(rb.linearVelocityX, glideSpeed);
            }
            else
            {
                rb.gravityScale = startGravity;
                animator.SetBool("isGliding", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastSparkle();
        }
    }
void CastSparkle()
    {
        Vector2 direction = RightFacing ? Vector2.right : Vector2.left;
        Vector2 checkPos = (Vector2)transform.position + direction * detectionRange;
        if (sparkleSpell != null)
        {
            GameObject effect=Instantiate(sparkleSpell,checkPos,Quaternion.identity);
            Vector3 scale = effect.transform.localScale;
            scale.x=RightFacing?Mathf.Abs(scale.x):-Mathf.Abs(scale.x);
            effect.transform.localScale = scale;
            Destroy(effect,sparkleDuration);
        }
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(sparkleInteract))
            {
                hit.SendMessage("OnSparkleHit",SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Vector2 direction=RightFacing ? Vector2.right : Vector2.left;
        Vector2 checkPos = (Vector2)transform.position + direction * detectionRange;
        Collider2D[] hits = Physics2D.OverlapCircleAll(checkPos, interactRange);
        Gizmos.DrawWireSphere(checkPos, interactRange);
    }
}



