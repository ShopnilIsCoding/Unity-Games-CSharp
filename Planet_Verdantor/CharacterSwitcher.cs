using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public Camera camera1;
    public Camera camera2;

    private GameObject currentCharacter;
    private Camera currentCamera;

    public JoystickController currentCharacterJoystickController; // Add this reference
    private JumpButton currentJumpButton; // Add this reference
    private SecondObjectJumpButton currentSecondJumpButton; // Add this reference

    private void Start()
    {
        character2.SetActive(false);
        // Start with the first character and camera
        SwitchToCharacter(character1, camera1);
    }

    public void SwitchCharacters()
    {
        if (currentCharacter == character1)
        {
            SwitchToCharacter(character2, camera2);
            character1.SetActive(false); // Hide the first character
        }
        else
        {
            SwitchToCharacter(character1, camera1);
            character2.SetActive(false); // Hide the second character
        }
    }

    private void SwitchToCharacter(GameObject newCharacter, Camera newCamera)
    {
        // Stop movement of the previous character if it exists
        currentCharacterJoystickController = currentCharacter.GetComponent<JoystickController>();
        if (currentCharacterJoystickController != null)
        {
            currentCharacterJoystickController.StopMoving();
        }

        // Disable the current character and camera
        if (currentCharacter != null)
        {
            currentCharacter.SetActive(false);
            currentCamera.enabled = false;
        }

        // Enable the new character and camera
        newCharacter.SetActive(true);
        newCamera.enabled = true;

        // Update current references
        currentCharacter = newCharacter;
        currentCamera = newCamera;

        // Get the JoystickController of the new character
        currentCharacterJoystickController = currentCharacter.GetComponent<JoystickController>();

        // Update the jump button script's player reference
        currentJumpButton = currentCamera.GetComponent<JumpButton>();
        if (currentJumpButton != null)
        {
            currentJumpButton.player = newCharacter;
        }

        // Update the second jump button script's player reference
        currentSecondJumpButton = currentCamera.GetComponent<SecondObjectJumpButton>();
        if (currentSecondJumpButton != null)
        {
            currentSecondJumpButton.player = newCharacter;
        }
    }
}
