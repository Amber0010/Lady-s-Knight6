using UnityEngine;
using System.Collections;

public class Spiderweb : MonoBehaviour
{
    public float reformDelay = 2f;

    Animator anim;
    Collider2D col;

    Coroutine reformRoutine;

    void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    public void OnHit()
    {
        anim.SetTrigger("Hit");
        col.enabled = false;

        if (reformRoutine != null)
        {
            StopCoroutine(reformRoutine);
        }
        reformRoutine = StartCoroutine(ReformAfterDelay());
    }

    IEnumerator ReformAfterDelay()
    {
        yield return new WaitForSeconds(reformDelay);
        anim.SetTrigger("Reform");

        reformRoutine = null;

        col.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
            OnHit();
    }
}
