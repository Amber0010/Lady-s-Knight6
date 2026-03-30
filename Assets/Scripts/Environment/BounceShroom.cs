using UnityEngine;

public class BounceShroom : MonoBehaviour
{
    public float bounceForce = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SirRoly") || collision.gameObject.CompareTag("LadyBug")){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }

}
