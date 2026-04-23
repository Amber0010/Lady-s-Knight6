using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dText;
    public string[] lines;
    private int currentLine = 0;

    //LadyBugMovementNewAnim taking
    //    roly talking 
    //    neither = plain

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (lines.Length > 0)
        {
            dText.text = lines[0];
        }
    }
    public void NextLine()
    {
        currentLine++;
        if (currentLine < lines.Length)
        {
            dText.text = lines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }
    void EndDialogue()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    // Update is called once per frame
}
