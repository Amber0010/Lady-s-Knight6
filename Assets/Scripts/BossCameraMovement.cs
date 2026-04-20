using UnityEngine;

public class BossCameraMovement : MonoBehaviour
{
    public float CamSpeed = 2f;
    public float delay = 3f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            transform.position += Vector3.right * CamSpeed * Time.deltaTime;
        }

    }
}
