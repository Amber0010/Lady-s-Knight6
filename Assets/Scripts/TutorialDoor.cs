using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class TutorialDoor : MonoBehaviour
{
    [Header("Door Sprites")]
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;

    Animator animator;

    //private bool DoorOpen = false;

    private bool RolyAtDoor = false;
    private bool LadyAtDoor = false;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RolyAtDoor && LadyAtDoor)
        {
            BothAtDoor();
        }
    }
    private void OpenDoor()
    {
        //DoorOpen = true;
        StartCoroutine("WaitforAnim");
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
            OpenDoor();
            StartCoroutine("WaitforThoughts");
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
    IEnumerator WaitforAnim()
    {
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(1f);
    }
    IEnumerator WaitforThoughts()
    {
        yield return new WaitForSeconds(2f);
        LoadNextLevel();
    }
}
