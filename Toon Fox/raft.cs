using UnityEngine;

public class ContinuousForwardForce : MonoBehaviour
{
    public float forwardSpeed = 5.0f;  // Adjust this to set the forward speed
    public float forceDuration = 3.0f; // Adjust this to set the duration of the forward force

    private float elapsedTime = 0.0f;

    private void Update()
    {
        // If the elapsed time is less than the force duration, apply the force
        if (elapsedTime < forceDuration)
        {
            // Calculate the new position based on forwardSpeed
            Vector3 newPosition = transform.position + transform.forward * forwardSpeed * Time.deltaTime;

            // Update the object's position
            transform.position = newPosition;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
        }
    }
}
