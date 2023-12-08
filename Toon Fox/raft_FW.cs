using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Raft_FW : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject objectToMove;
    public float moveSpeed = 5f; // Adjust the speed as needed
    public GameObject particle;
    public GameObject lowerparticle;

    private bool isButtonDown = false;

    private void Start()
    {
        particle.gameObject.SetActive(false);
        lowerparticle.gameObject.SetActive(true);
    }
    private void Update()
    {
        // Move the object forward while the button is held down
        if (isButtonDown)
        {
            objectToMove.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            particle.gameObject.SetActive(true);
            lowerparticle.gameObject.SetActive(false);
        }
        else
        {
            particle.gameObject.SetActive(false);
            lowerparticle.gameObject.SetActive(true);
        }
  
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonDown = false;
    }
}
