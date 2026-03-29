using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched: " + collision.name);
        ICollection item = collision.GetComponent<ICollection>();
        if (item!= null)
        {
            item.Collect();
        }
    }
}
