using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class jump_button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool ispressed = false;
    public GameObject Player;
    public float Force;


    // Update is called once per frame
    void Update()
    {
        if (ispressed)
        {
            Player.transform.Translate(0, Force * Time.deltaTime, 0);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }
    public void OnPointerUp(PointerEventData eventData) 
    {
        ispressed = false;
    }
}
