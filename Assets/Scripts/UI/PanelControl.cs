using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Panel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void LastBeginningPanel()
    {
        SceneManager.LoadScene(2);
    }

    public void LastEndPanel()
    {
        SceneManager.LoadScene(0);
    }
    public void SplashPanel()
    {
        SceneManager.LoadScene(5);
    }
}
