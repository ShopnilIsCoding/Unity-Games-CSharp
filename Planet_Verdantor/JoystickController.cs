using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Transform objectToMove;
    public Animator animator;
    public float moveSpeed = 5f;
    public LayerMask groundLayer;

    private Vector3 inputDirection;
    private bool isJumping;

    public bool IsMovingInDirection(Vector3 direction)
    {
        return inputDirection == direction;
    }

    public void StopMoving()
    {
        SetInputDirection(Vector3.zero);
    }

    public void SetInputDirection(Vector3 direction)
    {
        inputDirection = direction;
        UpdateAnimation();
    }

    private bool IsOnGround()
    {
        Vector3 rayOrigin = objectToMove.position + Vector3.up * 0.1f;
        float rayDistance = 0.2f;
        return Physics.Raycast(rayOrigin, Vector3.down, rayDistance, groundLayer);
    }

    private void Update()
    {
        bool isOnGround = IsOnGround();
        isJumping = !isOnGround;

        if (inputDirection != Vector3.zero)
        {
            Vector3 movement = inputDirection.normalized * moveSpeed * Time.deltaTime;
            objectToMove.Translate(movement);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        bool isWalking = inputDirection.magnitude > 0;
        animator.SetBool("IsOnGround", !isJumping); // Set IsOnGround parameter in animator
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
    }
}
