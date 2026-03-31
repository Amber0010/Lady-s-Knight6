using UnityEngine;
using UnityEngine.UI;

public class TutorialCameraBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float minX;
    public float maxX;

    public GameObject ladyBug;
    public GameObject rolyStateA;
    public GameObject rolyStateB;

    //public float cameraSpeed;
    private Vector3 velocity = Vector3.zero;

    private float clampedX;

    private Vector3 ladyBugPosition;
    private Vector3 sirRolyPosition;

    private Vector3 averagePos;


    void Start()
    {
        //currentX = transform.position.x;
        //currentY = transform.position.y;
        //currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ladyBugPosition = ladyBug.transform.position;
        if (rolyStateA.activeInHierarchy)
        {
            sirRolyPosition = rolyStateA.transform.position;
        }
        else
        {
            sirRolyPosition = rolyStateB.transform.position;
        }

        averagePos = (ladyBugPosition + sirRolyPosition) / 2;
        averagePos.z = transform.position.z;

        clampedX = Mathf.Clamp(averagePos.x, minX, maxX);

        Vector3 targetPos = new Vector3(clampedX, 0f, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.15f);

        //Debug.DrawLine(ladyBugPosition, sirRolyPosition, Color.red);
        //Debug.DrawLine(averagePos, averagePos + Vector3.up, Color.green);
    }
    //if (averagePos.x != currentX || averagePos.y != currentY)
    //{
    //    if (averagePos.x <= minX && averagePos.y <= minY && averagePos.x >= maxX && averagePos.y <= maxY)
    //    {
    //        Vector3.Lerp(ladyBugPosition, sirRolyPosition, 0.5f);
    //        currentPos = transform.position;
    //        currentY = currentPos.y;
    //        currentX = currentPos.x;
    //    }
    //}
}
