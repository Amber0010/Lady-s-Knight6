using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Lady;
    public GameObject SirRoly;
    public GameObject SirRolyRolled;
    public bool RolyAtDoor = false;
    public bool LadyAtDoor = false;
    //private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = closedDoor;
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
        //StartCoroutine("WaitforAnim");
        //spriteRenderer.sprite=openDoor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Transform root = collision.transform.root;


        if (collision.gameObject == SirRoly || SirRolyRolled)
        {
            Debug.Log("roly collision enter");
            RolyAtDoor = true;
        }
        if (collision.gameObject == Lady)
        {
            LadyAtDoor = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform root = collision.transform.root;

        if (root.CompareTag("SirRoly"))
        {
            Debug.Log("roly collision exit");
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
    //IEnumerator WaitforAnim()
    //{
    //    //animator.SetTrigger("Open");
    //    yield return new WaitForSeconds(1f);
    //}
    IEnumerator WaitforThoughts()
    {
        yield return new WaitForSeconds(2f);
        LoadNextLevel();
    }
}
