using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioClip myClipE;
    public AudioClip myClipF;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void ButtonSound1()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(myClipE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
