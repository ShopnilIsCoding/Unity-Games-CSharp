using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger : MonoBehaviour
{
    public GameObject ui;
    void Start()
    {
        ui.SetActive(false);
    }

  
    private void OnTriggerStay(Collider other)
    {
      if(other.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        { ui.SetActive(false); }
    }
}
