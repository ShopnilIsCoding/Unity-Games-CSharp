using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raft_enter_exit : MonoBehaviour
{
    public MonoBehaviour rotation;
    public Transform player;
    public Transform raft;
    public GameObject drive_ui;
    public GameObject Exit_ui;
    public GameObject control_ui;
    bool candrive;
    bool driving;
    void Start()
    {
        drive_ui.gameObject.SetActive(false);
        Exit_ui.gameObject.SetActive(false);
        control_ui.gameObject.SetActive(false);
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        if(candrive)
        {
            drive_ui.gameObject.SetActive(true);
        }
        else
        {
            drive_ui.gameObject.SetActive(false);
        }
        if(candrive && driving)
        {
            drive_ui.gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            candrive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            candrive = false;
        }
    }
    public void Drivebutton_Clicked()
    {
        player.transform.SetParent(raft);
        Exit_ui.gameObject.SetActive(true);
        control_ui.gameObject.SetActive(true);
        driving = true;
        rotation.enabled = true;

    }
    public void Exitbutton_clicked()
    {
        player.transform.SetParent(null);
        Exit_ui.SetActive(false);
        control_ui.gameObject.SetActive(false);
        driving=false;
        rotation.enabled = false;
    }
}
