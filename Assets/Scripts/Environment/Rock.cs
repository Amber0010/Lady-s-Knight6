using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sirRoly;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (sirRoly.GetComponent<SirRolyMovementNewAnim>().isRolled)
        {
            animator.SetTrigger("Break");
        }
    }

    public void Break()
    {
        Destroy(this.gameObject);
    }
}
