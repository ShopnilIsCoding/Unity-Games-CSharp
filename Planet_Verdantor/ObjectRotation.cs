using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationAmount = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(Vector3.up, rotationAmount);
            }
        }
    }
}
