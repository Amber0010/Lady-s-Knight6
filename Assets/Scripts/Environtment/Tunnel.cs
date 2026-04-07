using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public Transform entrance1;
    public Transform entrance2;

    public GameObject sirRolyRolled;

    bool playerInside = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && sirRolyRolled.GetComponentInParent<SirRolyMovementNewAnim>().isRolled && Input.GetKeyDown(KeyCode.O))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        float dist1 = Vector2.Distance(sirRolyRolled.transform.position, entrance1.position);
        float dist2 = Vector2.Distance(sirRolyRolled.transform.position, entrance2.position);

        if (dist1 < dist2)
        {
            sirRolyRolled.transform.position = entrance2.position;
        }
        else
        {
            sirRolyRolled.transform.position = entrance1.position;
        } 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == sirRolyRolled)
        {
            playerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == sirRolyRolled)
        {
            playerInside = false;
        }
    }
}
