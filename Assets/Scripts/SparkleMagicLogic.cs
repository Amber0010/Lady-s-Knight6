using UnityEngine;

public class SparkleMagicLogic : MonoBehaviour
{
    public float speed = 6f;
    public float SparkleRange = .2f;
    private Transform target;
   
    public void setTarget(Transform newTarget)
    {
        target= newTarget;
        Debug.Log("Target set to: " + target.name);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Debug.Log("Sparkle lost target");
            Destroy(gameObject, 1f);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) <= SparkleRange)
        {
            Debug.Log("Sparkle reached target: " + target.name);
            BounceShroom shroom=target.GetComponentInParent<BounceShroom>();
           
            if (shroom != null)
            {
                shroom = target.GetComponentInParent<BounceShroom>();
                shroom.OnSparkleHit();
            }
            else
            {
                target.SendMessage("OnSparkleHit", SendMessageOptions.DontRequireReceiver);
                if (target.parent != null)
                {
                    target.parent.SendMessage("OnSparkleHit", SendMessageOptions.DontRequireReceiver);
                }
            }
            
            Destroy(gameObject);
        }
    }
}
