using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirRolyController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 2f;
    Rigidbody2D rb;

    public bool isRolled = false;

    public GameObject normalState;
    public GameObject rolledState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            changeState();
            rolyState();
            ResetRB();
        }

    }
    public bool IsRolled()
    {
        return isRolled;
    }

    public void changeState()
    {
        isRolled = !isRolled;
    }

    public void rolyState()
    {
        if (!isRolled)
        {
            normalState.transform.position = rolledState.transform.position;
            normalState.SetActive(true);
            rolledState.SetActive(false);
        }
        if (isRolled)
        {
            rolledState.transform.position = normalState.transform.position;
            normalState.SetActive(false);
            rolledState.SetActive(true);
        }
    }

    private void ResetRB()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }
}
