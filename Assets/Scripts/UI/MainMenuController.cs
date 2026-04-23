using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(10);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
