using UnityEngine;
using UnityEngine.InputSystem;

public class Lady_Movement : MonoBehaviour
{
    public InputActionAsset asset;
    public float speed = 6f;
    public float jumpForce = 4f;
    InputActionMap inputActions;
    InputAction move;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = asset.FindActionMap("LadyButtons");
        move = inputActions.FindAction("MoveL");
        inputActions.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementDir = move.ReadValue<Vector2>();
        transform.position = new Vector3(transform.position.x + movementDir.x * speed, transform.position.y + movementDir.y * speed, 0);

    }
}