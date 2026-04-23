using UnityEngine;
using UnityEngine.Rendering;
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
    public bool DoorOpen = false;

    private bool RolyAtDoor = false;
    private bool LadyAtDoor = false;
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
        if (CurrClovers >= totalClovers && !DoorOpen)
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

        Transform root = collision.transform.root;

        if (root.CompareTag("SirRoly"))
        {
            RolyAtDoor = true;
        }
        if (root.CompareTag("LadyBug"))
        {
            LadyAtDoor = true;
        }
        if (DoorOpen)
        {
            BothAtDoor();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform root = collision.transform.root;

        if (root.CompareTag("SirRoly"))
        {
            RolyAtDoor = false;
        }
        if (root.CompareTag("LadyBug"))
        {
            LadyAtDoor = false;
        }
    }
    void BothAtDoor()
    {
        if (RolyAtDoor && LadyAtDoor)
        {
            LoadNextLevel();
        }
    }
    void LoadNextLevel()
    {
        int currIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}
