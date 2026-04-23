using UnityEngine;

public class DoorSignSpriteChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private DoorExit doorExitScript;
    private SpriteRenderer sprite;
    public Sprite openSprite;

    void Start()
    {
        doorExitScript = GetComponentInParent<DoorExit>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorExitScript.DoorOpen)
        {
            sprite.sprite = openSprite;
        }
    }
}
