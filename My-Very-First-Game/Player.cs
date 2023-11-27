using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Rigidbody rb;
    public float forwardSpeed;
    private Animator animation;
    private Animator anim_land;
    private bool isJumping = false;

    public ParticleSystem jumpParticle; // Drag and drop particle prefab here

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
        anim_land = GetComponent<Animator>();
    }

    void Update()
    {
        if (isJumping)
        {
            animation.SetBool("isJumping", true);
            isJumping = false;
        }

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animation.SetBool("isJumping", false);
            anim_land.SetBool("inAir", false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isJumping = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // You can add any behavior for releasing the button here, if needed.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
