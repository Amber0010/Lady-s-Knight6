using System.Collections;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class WandAttackOnly : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    float dir = -1f;

    public float bobSpeed = 2f;
    public float bobHeight = .05f;

    //private bool isOveriding = false;

    //float z = 0f;

    Vector3 normalPos = new Vector3(0.46f, -0.028f, 0f);
    Quaternion normalRotation = Quaternion.Euler(0, 0, -20f);

    Vector3 animStartPos = new Vector3(0.339f, 0.277f, 0f);
    Vector3 animEndPos = new Vector3(0.483f, 0.049f, 0f);

    Vector3 walkStartPos = new Vector3(0.403f, 0.024f, 0f);
    Vector3 walkEndPos = new Vector3(0.237f, - 0.028f, 0f);

    Quaternion walkStartRotation = Quaternion.Euler(0, 0, -25f);
    Quaternion walkEndRotation = Quaternion.Euler(0, 0, -120f);

    Quaternion animStartRotation = Quaternion.Euler(0, 0, 30f);
    Quaternion animEndRotation = Quaternion.Euler(0, 0, -24f);

    private LadyBugMovementNewAnim ladyBug;
    private SpriteRenderer playerSR;
    private SpriteRenderer wandSR;

    public void Init(bool RightFacing)
    {
        dir = RightFacing ? -1f : 1f;
    }

    private void Start()
    {
        ladyBug = GetComponentInParent<LadyBugMovementNewAnim>();
        playerSR = ladyBug.GetComponentInChildren<SpriteRenderer>();
        wandSR = GetComponent<SpriteRenderer>();
        wandSR.enabled = false;
    }

    void Update()
    {
        //dir = playerSR.flipX ? 1f : -1f;

        //if (isOveriding) return;

        //if (Math.Abs(ladyBug.rb.linearVelocity.x) > 0)
        //{
        //    StartCoroutine(Walking());
        //}

        //float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        //transform.localPosition = new Vector3(-dir * normalPos.x, normalPos.y + yOffset);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(WandWave());
        }
    }

    IEnumerator WandWave()
    {
        //isOveriding = true;

        wandSR.enabled = true;

        float duration = .2f;
        float time = 0f;

        yield return new WaitForSeconds(.2f);

        transform.localPosition = animStartPos;

        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(animStartPos, animEndPos, time / duration);
            float baseZ = animStartRotation.eulerAngles.z;
            float deltaZ = animEndRotation.eulerAngles.z - baseZ;
            float z = baseZ + -dir * deltaZ * (time / duration);
            transform.localRotation = Quaternion.Euler(0f, 0f, z);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;

        while (time < duration)
        {
            transform.localPosition = Vector3.Lerp(animEndPos, normalPos, time / duration);
            float baseZ = animStartRotation.eulerAngles.z;
            float deltaZ = animEndRotation.eulerAngles.z - baseZ;
            float z = baseZ + -dir * deltaZ * (time / duration);
            transform.localRotation = Quaternion.Euler(0f, 0f, z);
            time += Time.deltaTime;
            yield return null;
        }

        wandSR.enabled = false;

        //isOveriding = false;
    }

    //IEnumerator Walking()
    //{
    //    isOveriding = true;

    //    float duration = .4f;
    //    float time = 0f;

    //    transform.localPosition = animStartPos;

    //    while (Math.Abs(ladyBug.rb.linearVelocity.x) > 0)
    //    {
    //        while (time < duration)
    //        {
    //            transform.localPosition = Vector3.Lerp(-dir * walkStartPos, walkEndPos, time / duration);
    //            float baseZ = walkStartRotation.eulerAngles.z;
    //            float deltaZ = walkEndRotation.eulerAngles.z - baseZ;
    //            float z = baseZ + -dir * deltaZ * (time / duration);
    //            transform.localRotation = Quaternion.Euler(0f, 0f, z);
    //            time += Time.deltaTime;
    //            yield return null;
    //        }

    //        time = 0f;

    //        while (time < duration)
    //        {
    //            transform.localPosition = Vector3.Lerp(-dir * walkEndPos, walkStartPos, time / duration);
    //            float baseZ = walkEndRotation.eulerAngles.z;
    //            float deltaZ = walkStartRotation.eulerAngles.z - baseZ;
    //            float z = baseZ + -dir * deltaZ * (time / duration);
    //            transform.localRotation = Quaternion.Euler(0f, 0f, z);
    //            time += Time.deltaTime;
    //            yield return null;
    //        }

    //        time = 0;
    //    }

    //    while (time < duration)
    //    {
    //        transform.localPosition = Vector3.Lerp(-dir * walkEndPos, normalPos, time / .2f);
    //        float baseZ = walkEndRotation.eulerAngles.z;
    //        float deltaZ = normalRotation.eulerAngles.z - baseZ;
    //        float z = baseZ + -dir * deltaZ * (time / .2f);
    //        transform.localRotation = Quaternion.Euler(0f, 0f, z);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }

    //    isOveriding = false;
    //}
}
