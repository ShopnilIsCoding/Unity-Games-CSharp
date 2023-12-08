using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            // Only consider touches on the right side of the screen
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    float rotationAmount = touch.deltaPosition.x * rotationSpeed;

                    // Incrementally apply the rotation using local rotation
                    transform.localRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
                }
            }
        }
    }
}
