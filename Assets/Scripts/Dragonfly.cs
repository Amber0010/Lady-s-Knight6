using UnityEngine;

public class Dragonfly : MonoBehaviour
{

    private float speed = 8f;

    //private Vector3 startPos;
    private Vector3 endPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //startPos = transform.position;
        endPos = new Vector3(60f, transform.position.y, transform.position.z);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
}
