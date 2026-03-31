using UnityEngine;

public class Test : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSparkleHit()
    {
        Debug.Log("OnSparkleHit activated");
        animator.SetTrigger("Sparkle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter activated");
        if (collision.gameObject.tag == "Magic")
        {
            OnSparkleHit();
        }
    }
}
