using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private ForwardVelocityManager forwardVelocityManager;
    private RotationManager rotationManager;

    private void Awake()
    {
        rotationManager = GetComponent<RotationManager>();
        forwardVelocityManager = GetComponent<ForwardVelocityManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(!context.performed && !context.canceled) 
            return;
        
        var inputValue = context.ReadValue<Vector2>();
        var horizontalInput = inputValue.x;
        if(horizontalInput != 0)
            rotationManager.StartRotation(horizontalInput);
        else
            rotationManager.StopRotation();

        var verticalInput = inputValue.y;
        forwardVelocityManager.StartMoving(verticalInput);
    }
}
