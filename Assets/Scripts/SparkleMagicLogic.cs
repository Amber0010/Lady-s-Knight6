using UnityEngine;

public class SparkleMagicLogic : MonoBehaviour
{
    public float speed = 8f;
    public float SparkleRange = .2f;
    private Transform target;
   
    public void setTarget(Transform newTarget)
    {
        target= newTarget;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject, 1f);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) <= SparkleRange)
        {
            target.SendMessage("OnSparkleHit", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
