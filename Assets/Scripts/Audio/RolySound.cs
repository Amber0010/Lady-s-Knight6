using UnityEngine;

public class RolySound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip myClipC;
    public AudioClip myClipD;
    public AudioClip myClipE;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        if (Input.GetKeyDown(KeyCode.I)){
            audioSource.PlayOneShot(myClipC);
        } else if (Input.GetKeyDown(KeyCode.U)){
            audioSource.PlayOneShot(myClipD);
        } else if (Input.GetKeyDown(KeyCode.O)){
            audioSource.PlayOneShot(myClipE);
    }
}
}
