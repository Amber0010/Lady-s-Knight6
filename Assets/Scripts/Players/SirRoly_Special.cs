using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SirRoly_Special : MonoBehaviour
{
    public bool isRolled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            isRolled = true;
        }
        else
        {
            isRolled = false;
        }

    }

    public bool IsRolled()
    {
        return isRolled;
    }
}
