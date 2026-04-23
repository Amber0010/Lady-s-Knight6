using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public MonoBehaviour rolyController;
    public MonoBehaviour ladyController;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);

        rolyController.enabled = false;
        ladyController.enabled = false;
        Time.timeScale = 0f;

        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        rolyController.enabled = true;
        ladyController.enabled = true;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
