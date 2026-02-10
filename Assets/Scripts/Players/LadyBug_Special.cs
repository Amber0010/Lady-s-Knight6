using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LadyBug_Special : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform magicSpawnPoint;
    public GameObject magic;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //In future, add code so that the magic spawns in the direction LadyBug is facing. Currently just moves right. 

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(magic, magicSpawnPoint.position, Quaternion.identity);
        }
    }
}