using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcher : MonoBehaviour
{
    public GameObject character;
    public GameObject car;
    
     void OnButtonClicked()
        {
        character.transform.parent = car.transform;
        character.SetActive(false);
        }
   public void OnButtonClickedAgain()
    {
        character.SetActive(true);
        character.transform.parent = null;
    }
}
