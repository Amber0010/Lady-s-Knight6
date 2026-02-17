using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sirRoly;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (sirRoly.GetComponent<SirRoly_Special>())
            //Destroy(this.gameObject);
    }
}
