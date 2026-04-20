
using UnityEngine;

public class LossCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform root = collision.transform.root;
        if (root.CompareTag("SirRoly") || root.CompareTag("LadyBug"))
        {
            Destroy(root.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}

