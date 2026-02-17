using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public float speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        //public bool travelingDirection = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (travelingDirection == true)
            transform.position += transform.right * Time.deltaTime * speed;     
        //if (travelingDirection == false)
        //    transform.position += transform.right * Time.deltaTime * speed;
    }
}
