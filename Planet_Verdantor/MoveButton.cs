using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerDownHandler
{
    public ObjectSwitcher objectSwitcher; // Reference to the ObjectSwitcher script

    public Vector3 movementDirection;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (objectSwitcher.currentCharacterJoystickController != null)
        {
            JoystickController joystickController = objectSwitcher.currentCharacterJoystickController;

            if (joystickController.IsMovingInDirection(movementDirection))
            {
                joystickController.StopMoving();
            }
            else
            {
                joystickController.SetInputDirection(movementDirection);
            }
        }
    }
}
