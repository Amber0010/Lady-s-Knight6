using UnityEngine;

public class BossCameraMovement : MonoBehaviour
{
    public float CamSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * CamSpeed * Time.deltaTime; 
    }
}
