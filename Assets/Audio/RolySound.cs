using UnityEngine;

public class RolySound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip Jump;
    public SirRolyMovementNewAnim rolyMovement;
    public AudioClip Roll;
    public AudioClip Special;
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
            audioSource.PlayOneShot(Jump);
        } else if (Input.GetKeyDown(KeyCode.U)){
            audioSource.PlayOneShot(Roll, 2f);
        } else if (Input.GetKeyDown(KeyCode.O)&& !rolyMovement.isRolled){
            audioSource.PlayOneShot(Special, 0.5f);
            

        }
}
}
