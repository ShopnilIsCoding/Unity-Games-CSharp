using UnityEngine;

public class CameraFollowPelvis : MonoBehaviour
{
    public Transform pelvisTransform; // Reference to the character's pelvis transform

    private Vector3 initialLocalPosition;

    private void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    private void LateUpdate()
    {
        // Match the camera's position to the pelvis's position while considering local position
        transform.position = pelvisTransform.TransformPoint(initialLocalPosition);

        // Reset the camera's local rotation
        transform.localRotation = Quaternion.identity;
    }
}
