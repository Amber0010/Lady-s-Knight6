using UnityEngine;
using System.Collections;

public class StickBug : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 idleState;
    [SerializeField] float dropDelay, resetTime;

    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        idleState = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D stand)
    {
        if (stand.gameObject.CompareTag ("SirRoly"))
        {
            StartCoroutine(PlatformDrop());
        }
    }
    IEnumerator PlatformDrop()
    {
        yield return new WaitForSeconds(dropDelay);
        animator.SetTrigger("Fall");
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(resetTime);
        //ResetP();
    }
    private void ResetP()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
        transform.position = idleState;
    }
}
// Update is called once per frame
