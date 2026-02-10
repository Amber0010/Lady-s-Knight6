using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp_Plant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ramp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Destroy(other.gameObject);
            ramp.SetActive(true);
        }

    }
}