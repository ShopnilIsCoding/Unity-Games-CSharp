using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // Adjust the speed of rotation in degrees per second

    private float currentRotation = 0.0f;
    private bool rotatePositive = true;

    void Update()
    {
        // Calculate the target rotation based on the current direction
        float targetRotation = rotatePositive ? 5.0f : -5.0f;

        // Calculate the new rotation based on the speed
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0.0f, 90.0f, currentRotation);

        // Check if we reached the target rotation
        if (Mathf.Approximately(currentRotation, targetRotation))
        {
            // Toggle the direction
            rotatePositive = !rotatePositive;
        }
    }
}
