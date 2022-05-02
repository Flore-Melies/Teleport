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
        // Si on est ni en performed ni en canceled on ne fait rien
        if (!context.performed && !context.canceled)
            return;

        var inputValue = context.ReadValue<Vector2>();
        // horizontalInput est compris entre -1 & 1 car c’est un axe d’input
        // Donc on peut lancer une rotation positive ou négative (d’où le fait que ça tourne à droite ou à gauche)
        var horizontalInput = inputValue.x;
        if (horizontalInput != 0)
            rotationManager.StartRotation(horizontalInput);
        else
            rotationManager.StopRotation();

        // verticalInput est compris entre -1 & 1 car c’est un axe d’input
        // Donc on peut lancer un déplacement positif ou négatif (d’où le fait qu’on avance et recule)
        var verticalInput = inputValue.y;
        if (verticalInput != 0)
            forwardVelocityManager.StartMoving(verticalInput);
        else
            forwardVelocityManager.StopMoving();
    }
}
