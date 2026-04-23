using UnityEngine;

public class LossCondition : MonoBehaviour
{
    public GameObject LossScreen;
    private bool gameOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOver)
        {
            return;
        }
        Transform root = collision.transform.root;
        if (root.CompareTag("SirRoly") || root.CompareTag("LadyBug"))
        {
            gameOver = true;
            Time.timeScale = 0f;
            LossScreen.SetActive(true);
           root.gameObject.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}

