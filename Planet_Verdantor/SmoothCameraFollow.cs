using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed; // Adjust this for camera movement smoothness
    private Quaternion _rotationOffset;

    private void Awake()
    {
        _offset = transform.position - target.position;
        _rotationOffset = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _rotationOffset * _offset; // Apply rotation offset to the offset

        // Smoothly move the camera's position towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Look at the target's position
        transform.LookAt(target.position);
    }
}
