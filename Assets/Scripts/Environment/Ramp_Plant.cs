using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp_Plant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject before;
    public GameObject after;

    private Animator beforeAnimator;
    private Animator afterAnimator;

    private Vector3 beforePos;
    private Vector3 originalBeforePos;
    private Vector3 afterPos;
    private Vector3 originalAfterPos;

    private bool isTransitioning = false;
    private bool goingToAfter = true;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        beforePos = before.transform.position;
        afterPos = after.transform.position;

        originalBeforePos = before.transform.position;
        originalAfterPos = after.transform.position;

        beforeAnimator = before.GetComponent<Animator>();
        afterAnimator = after.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransitioning) return;

        if (goingToAfter)
        {
            before.transform.position = Vector3.SmoothDamp(before.transform.position, afterPos, ref velocity, 0.5f);
        }
        else
        {
            after.transform.position = Vector3.SmoothDamp(after.transform.position, beforePos, ref velocity, 0.5f);
        }
    }
        //if (!before.activeInHierarchy)
        //{
        //    transform.position = originalBeforePos;
        //}
        //if (!after.activeInHierarchy)
        //{
        //    transform.position = originalAfterPos;
        //}
    void OnSparkleHit()
    {
        if (isTransitioning) return;

        isTransitioning = true;

        if (before.activeInHierarchy)
        {
            goingToAfter = true;
            beforeAnimator.SetTrigger("Sparkle");
        }
        else
        {
            goingToAfter = false;
            afterAnimator.SetTrigger("Sparkle");
        }
        //if(before.activeInHierarchy && beforeAnimator != null)
        //{
        //    beforeAnimator.SetTrigger("Sparkle");
        //    before.transform.position = Vector3.SmoothDamp(before.transform.position, after.transform.position, ref velocity, 0.15f);
        //}
        //if (after.activeInHierarchy && afterAnimator != null)
        //{
        //    afterAnimator.SetTrigger("Sparkle");
        //    after.transform.position = Vector3.SmoothDamp(after.transform.position, before.transform.position, ref velocity, 0.15f);
        //}
    }
    public void FinishTransition()
    {
        Debug.Log("FinishTransition called");

        if (goingToAfter)
        {
            before.SetActive(false);
            after.SetActive(true);
        }
        else
        {
            after.SetActive(false);
            before.SetActive(true);
        }

        isTransitioning = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Destroy(other.gameObject);
            //OnSparkleHit();
        }
    }
}