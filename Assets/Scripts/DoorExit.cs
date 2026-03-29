using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [Header("Door Sprites")]
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;


    Animator animator;

    private int totalClovers;
    private int CurrClovers = 0;
    private bool DoorOpen = false;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        CloverLeaf.OnCloverCollect += HandleCloverCollected;
    }
    private void OnDisable()
    {
        CloverLeaf.OnCloverCollect -= HandleCloverCollected;
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        totalClovers = FindObjectsByType<CloverLeaf>(FindObjectsSortMode.None).Length;
        spriteRenderer.sprite = closedDoor;
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void HandleCloverCollected(int num)
    {
        CurrClovers += num;
        if (CurrClovers>=totalClovers && !DoorOpen)
        {
            OpenDoor();
        }
    }
    private void OpenDoor()
    {
        DoorOpen = true;
        animator.SetTrigger("Open");
        //spriteRenderer.sprite=openDoor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DoorOpen) return;
        if (collision.CompareTag("SirRoly") && collision.CompareTag("LadyBug"))
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
