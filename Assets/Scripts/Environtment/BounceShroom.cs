using UnityEngine;

public class BounceShroom : MonoBehaviour
{
    public float bounceForce = 10f;
    private bool IsBouncy = false;
    public void OnSparkleHit()
    {
        Debug.Log("SHROOM HIT");
        IsBouncy = true;
        transform.localScale = new Vector3(1.2f, 1.2f, 1f);

        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsBouncy)
        {
            return;
        }
        Transform playerRoot=collision.transform.root;
        if (playerRoot.CompareTag("SirRoly") || playerRoot.CompareTag("LadyBug"))
        {
            Rigidbody2D rb=playerRoot.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.AddForce(Vector2.up *bounceForce,ForceMode2D.Impulse);
            }
   
        }

    }

}
