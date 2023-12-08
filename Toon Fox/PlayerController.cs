using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider))]
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] public FixedJoystick joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float BackwardMoveSpeedMultiplier = 0.5f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float forwardJumpForce;
    [SerializeField] private float doubleJumpForce;
    [SerializeField] private float jumpCooldown = 0.5f; // Cooldown duration in seconds
    public GameObject footstep;
    public GameObject backstep;
    public GameObject flip;
    public AudioSource dieAudioSource;
    public AudioSource sleepaudio;

    private bool isMoving = false;
    public bool isGrounded = false;
    private bool canJump = true; // Whether the character can jump
    private bool hasDoubleJumped = false; // Whether the double jump has been used
    private bool isDead=false;
    
    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("isJumping", false);
        footstep.SetActive(false);
        backstep.SetActive(false);
        flip.SetActive(false);
        dieAudioSource.Stop();
        sleepaudio.Stop();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            hasDoubleJumped = false; // Reset double jump on landing
            flip.SetActive(false);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (isGrounded && canJump)
        {
            PerformJump(jumpForce, false);
        }
        else if (!isGrounded && !hasDoubleJumped)
        {
            PerformJump(doubleJumpForce, true);
            hasDoubleJumped = true;
            flip.SetActive(true);
        }

    }

    private void PerformJump(float jumpForce, bool isDoubleJump)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity
        
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Vector3 forwardForce = transform.forward * forwardJumpForce;
        rb.AddForce(forwardForce, ForceMode.Impulse);
        
        if (isDoubleJump)
        {
            // Trigger somersault animation
            flip.SetActive(true);
            animator.SetTrigger("Somersault");
        }
        else
        {
            // Normal jump animation
            animator.SetBool("isJumping", true);
            StartCoroutine(ResetJumpAnimation());
        }

        // Disable jumping for the cooldown duration
        canJump = false;
        StartCoroutine(EnableJumpAfterCooldown());
    }

    private IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length - 1.5f);
        animator.SetBool("isJumping", false);
    }

    private IEnumerator EnableJumpAfterCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    void FixedUpdate()
    {
        float verticalInput = joystick.Vertical;

        // joystick input to world space
        Vector3 moveInput = new Vector3(0, 0, verticalInput);
        moveInput = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * moveInput;

        // speed reduction if moving backward
        float speedMultiplier = 1f;
        if (verticalInput < 0) //backward
        {
            speedMultiplier = BackwardMoveSpeedMultiplier;
        }

        rb.velocity = moveInput * MoveSpeed * speedMultiplier + new Vector3(0, rb.velocity.y, 0);
        if(verticalInput > 0 && isGrounded == true) 
        {
            footstep.SetActive(true);
        }
        else { footstep.SetActive(false); }
        if (verticalInput < 0 && isGrounded == true)
        {
            backstep.SetActive(true);
        }
        else { backstep.SetActive(false); }

        // blend tree parameters
        animator.SetFloat("Vertical", verticalInput);

        isMoving = Mathf.Abs(verticalInput) > 0;
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsDead", isDead);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dead"))
        {
            // Play the death sound
            dieAudioSource.Play();

            isDead = true;

            // Wait for the audio clip to finish playing (plus a buffer time)
            StartCoroutine(ReloadSceneAfterDeath());
        }
        else if(other.gameObject.CompareTag("next level"))
        {
            SceneManager.LoadScene("Demo Night");
        }
        if(other.gameObject.CompareTag("Raft"))
        {
            sleepaudio.Play();
            animator.SetBool("isDriving",true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Raft"))
        {
            sleepaudio.Stop();
            animator.SetBool("isDriving", false);

        }
    }

    private IEnumerator ReloadSceneAfterDeath()
    {
        // Wait for the audio clip's duration plus a buffer time
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Reload the scene
        SceneManager.LoadScene("Demo Blend");
    }

}
