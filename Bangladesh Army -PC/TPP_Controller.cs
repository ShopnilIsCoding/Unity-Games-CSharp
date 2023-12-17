using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TPP_Controller : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cam;
    public Animator animator;
    public Transform groundcheck;
    public float groundRadius = 0.3f;
    public LayerMask Ground;

    public float speed = 3.0f;
    public float gravity = -9.81f;
    public float smoothTime = 0.1f;
    float smoothVelocity;
    Vector3 lowerForce;
    bool isGrounded;
    bool isMoving;
    private bool isMouseButtonDown;
    private bool isMouseButtonDown2;


    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        isMouseButtonDown = Input.GetKey(KeyCode.Mouse0);
        isMouseButtonDown2 = Input.GetKey (KeyCode.Mouse1);
    float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (!isMouseButtonDown || !isMouseButtonDown2)
        {
            if (Input.GetKey(KeyCode.LeftShift) && (direction.magnitude > 0.1f))
            {
                speed = 6.0f;
                animator.SetBool("running", true);

            }
            else
            {
                speed = 3.0f;
                animator.SetBool("running", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && (direction.magnitude > 0.1f))
            {
               
                animator.SetBool("jumpOver", true);
                //characterController.center = new Vector3(0f, 1.389f, 0f);
            }
            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("jumpOver"))
            {
                
                animator.SetBool("jumpOver", false);
                //characterController.center = new Vector3(0f, 0.889f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && (direction.magnitude > 0.1f))
            {
               
                animator.SetBool("rollOver", true);
            }
            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("rollOver"))
            {
                
                animator.SetBool("rollOver", false);
            }
        }

        if (direction.magnitude > 0.1f)
        {

            animator.SetBool("walking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);

            
        }
        else
            animator.SetBool("walking", false);

        lowerForce.y += gravity * Time.deltaTime;
        characterController.Move(lowerForce * Time.deltaTime);
        isMoving = direction.magnitude > 0.1f;
        if (isMouseButtonDown && !isMoving && isGrounded)
        {
            animator.SetBool("MouseL",true);

        }
        else
        {
            animator.SetBool("MouseL", false);
        }

        if (isMouseButtonDown2 && !isMoving && isGrounded)
        {
            animator.SetBool("MouseR", true);

        }
        else
        {
            animator.SetBool("MouseR", false);
        }



        isGrounded = Physics.CheckSphere(groundcheck.position, groundRadius, Ground);
        if (isGrounded && lowerForce.y <0) 
        {
            lowerForce.y = -2f;
        }
        if(!isGrounded) 
        {
            animator.SetBool("falling", true);
        }
        else
        {
            animator.SetBool("falling", false);
        }
    }

}
