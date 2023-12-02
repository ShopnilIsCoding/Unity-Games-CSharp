using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    bool isJumping = false;
    public GameObject player;
    public float jumpForce;
    public Animator playerAnimator;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    void Update()
    {
        if (isPressed)
        {
            Jump();
        }
        else if (isJumping)
        {
            isJumping = false;
            playerAnimator.SetBool("isJumping", false); // Transition to idle/walk animation
        }
    }

    void Jump()
    {
        if (!isJumping)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            playerAnimator.SetBool("isJumping", true); // Trigger the jump animation
        }
    }
}
