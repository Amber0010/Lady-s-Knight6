using UnityEngine;

public class elevatorPlant : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxHeight = 9f;
    public float riseSpeed = 2f;
    private Vector2 startPos;
    private Vector2 targetPos;
    private Vector2 endPos;
    private bool isRising=false;
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector2.up * maxHeight;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    { 
            transform.position=Vector2.MoveTowards(transform.position, targetPos, riseSpeed*Time.deltaTime);
    }
    void OnSparkleHit()
    {
        isRising = !isRising;
        if (isRising)
        {
        targetPos= endPos;
        }
        else
        {
            targetPos = startPos;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform playerRoot = collision.transform.root;
        if (playerRoot.CompareTag("SirRoly")|| playerRoot.CompareTag("LadyBug"))
        {
            ContactPoint2D contactPoint = collision.GetContact(0);
            if (contactPoint.normal.y > .5f)
            {
                playerRoot.SetParent(transform);
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Transform playerRoot = collision.transform.root;
        if (playerRoot.CompareTag("SirRoly")|| playerRoot.CompareTag("LadyBug"))
        {
            playerRoot.SetParent(null);
        }
    }
}
