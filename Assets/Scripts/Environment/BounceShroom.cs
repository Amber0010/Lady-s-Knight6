using UnityEngine;

public class BounceShroom : MonoBehaviour
{
    public float bounceForce = 4f;

    private bool bouncy = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnSparkleHit()
    {
        bouncy = !bouncy;
        if (bouncy) 
        {
            animator.SetTrigger("SparklePlus");
        }
        else if (!bouncy)
        {
            animator.SetTrigger("SparkleMinus");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bouncy)
        {
            if (collision.gameObject.CompareTag("SirRoly") || collision.gameObject.CompareTag("LadyBug"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
        }
 
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Magic")
    //    {
    //        OnSparkleHit();
    //    }
    //}

}
