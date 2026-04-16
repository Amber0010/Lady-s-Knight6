using UnityEngine;

public class LadyJump : MonoBehaviour

{   public AudioClip Jump;
    public AudioClip Magic;
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
            audioSource.PlayOneShot(Jump);
        } else if (Input.GetKeyDown(KeyCode.Q)){
            audioSource.PlayOneShot(Magic);
    }
}
}
