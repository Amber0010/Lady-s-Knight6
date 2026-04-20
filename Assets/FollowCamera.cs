using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float trail = -9.6f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x + trail, transform.position.y, transform.position.z);
    }
}


