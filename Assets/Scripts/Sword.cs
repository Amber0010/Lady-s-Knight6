using UnityEngine;

public class Sword : MonoBehaviour
{
    public float swingDegrees = 90f;
    public float swingTime = 0.15f;

    float startZ;
    float t;
    float dir = -1f;

    public void Init(bool facingRight)
    {
        dir = facingRight ? -1f : 1f;
    }

    void Start()
    {
        startZ = transform.eulerAngles.z;
    }

    void Update()
    {
        t += Time.deltaTime / swingTime;

        float z = startZ + dir * Mathf.Lerp(0f, swingDegrees, Mathf.Clamp01(t));
        transform.rotation = Quaternion.Euler(0f, 0f, z);

        if (t >= 1f) Destroy(gameObject);
    }
}
