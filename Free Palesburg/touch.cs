using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Joystick joystick; // Reference to your joystick

    public void OnPointerDown(PointerEventData eventData)
    {
        if (joystick != null)
        {
            joystick.OnPointerDown(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (joystick != null)
        {
            joystick.OnPointerUp(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (joystick != null)
        {
            joystick.OnDrag(eventData);
        }
    }
}
