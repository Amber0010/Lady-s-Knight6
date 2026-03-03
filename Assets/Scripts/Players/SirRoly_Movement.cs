using UnityEngine;
using UnityEngine.InputSystem;

public class SirRoly_Movement : MonoBehaviour
{
    public InputActionAsset asset;
    public float speed = 5f;
    public float jumpForce = 2f;
    InputActionMap inputActions;
    InputAction move;
    InputAction roll;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = asset.FindActionMap("RolyButtons");
        move = inputActions.FindAction("MoveR");
        inputActions.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementDir = move.ReadValue<Vector2>();
        transform.position = new Vector3(transform.position.x+movementDir.x*speed, transform.position.y+movementDir.y*speed, 0);

    }
}