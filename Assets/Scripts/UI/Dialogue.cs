using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;
        [TextArea(2, 4)]
        public string text;


    }
    public DialogueLine[] lines;
    public GameObject narrBox;
    public TMP_Text narrText;
    public GameObject ladyBox;
    public TMP_Text ladyText;
    public GameObject rolyBox;
    public TMP_Text rolyText;
    private int currLine = 0;
    void Start()
    {
        ShowLine();
    }
    public void NextLine()
    {
        currLine++;
        if (currLine < lines.Length)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }
    void ShowLine()
    {
        narrBox.SetActive(false);
        ladyBox.SetActive(false);
        rolyBox.SetActive(false);
        DialogueLine line = lines[currLine];
        if (line.speaker == "Lady")
        {
            ladyBox.SetActive(true);
            ladyText.text = line.text;
        }
        else if (line.speaker == "Roly")
        {
            rolyBox.SetActive(true);
            rolyText.text = line.text;
        }
        else if (line.speaker == "Narr")
        {
            narrBox.SetActive(true);
            narrText.text = line.text;
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
