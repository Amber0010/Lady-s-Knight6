using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp_Plant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject before;
    public GameObject after;

    public Animator beforeAnimator;
    public Animator afterAnimator;

    private Vector3 beforePos;
    public Vector3 originalBeforePos;
    private Vector3 afterPos;
    public Vector3 originalAfterPos;

    public bool moving = false;
    public float moveSpeed = 2.0f;
    public float rotateSpeed = 3.0f;

    public Quaternion originalBeforeRotation;
    public Quaternion originalAfterRotation;
    //private Vector3 velocity = Vector3.zero;

    void Start()
    {
        beforePos = before.transform.position;
        afterPos = after.transform.position;

        originalBeforePos = beforePos;
        originalAfterPos = afterPos;

        originalBeforeRotation = before.transform.localRotation;
        originalAfterRotation = after.transform.localRotation;

        beforeAnimator = before.GetComponent<Animator>();
        afterAnimator = after.GetComponent<Animator>();
    }

    public void FinishTransition()
    {
        Debug.Log("FinishTransition called");

        if (before.activeInHierarchy)
        {
            after.SetActive(true);
            before.SetActive(false);
            moving = false;
            after.GetComponent<Collider2D>().enabled = true;
            before.transform.position = originalBeforePos;
            before.transform.localRotation = originalBeforeRotation;
        }
        else if (after.activeInHierarchy)
        {
            before.SetActive(true);
            after.SetActive(false);
            moving = false;
            after.transform.position = originalAfterPos;
            after.transform.localRotation = originalAfterRotation;
        }
    }
    public void OnSparkleHit()
    {
        if (before.activeInHierarchy && beforeAnimator != null)
        {
            beforeAnimator.SetTrigger("Sparkle");
            moving = true;

            //before.transform.position = Vector3.SmoothDamp(before.transform.position, after.transform.position, ref velocity, 0.15f);
        }
        if (after.activeInHierarchy && afterAnimator != null)
        {
            afterAnimator.SetTrigger("Sparkle");
            after.GetComponent<Collider2D>().enabled = false;
            moving = true;
            //after.transform.position = Vector3.SmoothDamp(after.transform.position, before.transform.position, ref velocity, 0.15f);
        }
    }
}