using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirRoly_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 2f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }
}