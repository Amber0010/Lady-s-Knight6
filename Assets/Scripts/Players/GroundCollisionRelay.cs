using UnityEngine;

public class GroundCollisionRelay : MonoBehaviour
{

    private SirRoly_Movement control;
    void Start()
    {
        control = GetComponentInParent<SirRoly_Movement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            control.canJump = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.contacts[i].normal.y > 0.5f)
            {
                control.canJump = true;
                break;
            }
        }
    }


}
