using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class rampTrigger : MonoBehaviour
{
    private Ramp_Plant parentScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentScript = GetComponentInParent<Ramp_Plant>();
    }

    private void Update()
    {
        if (parentScript.moving)
        {
            if (parentScript.before.activeInHierarchy)
            {
                transform.position = Vector3.Lerp(transform.position, parentScript.originalAfterPos, parentScript.moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, parentScript.originalAfterRotation, parentScript.rotateSpeed * Time.deltaTime);
            }
            else if (parentScript.after.activeInHierarchy)
            {
                transform.position = Vector3.Lerp(transform.position, parentScript.originalBeforePos, parentScript.moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, parentScript.originalBeforeRotation, parentScript.rotateSpeed * Time.deltaTime);
            }
        }
    }

    public void FinishTransition()
    {
        parentScript.FinishTransition();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Destroy(other.gameObject);
            parentScript.OnSparkleHit();
        }
    }
}
