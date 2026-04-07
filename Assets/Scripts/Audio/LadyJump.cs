using UnityEngine;

public class LadyJump : MonoBehaviour

{   public AudioClip myClipA;
    public AudioClip myClipB;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        if (Input.GetKeyDown(KeyCode.W)){
            audioSource.PlayOneShot(myClipA);
        } else if (Input.GetKeyDown(KeyCode.E)){
            audioSource.PlayOneShot(myClipB);
    }
}
}
