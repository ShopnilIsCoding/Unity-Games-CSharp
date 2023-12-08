using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_coin : MonoBehaviour
{
    public AudioSource coin_sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coin_sound.Play();
            scoring_sys.theScore += 1;
            if (scoring_sys.theScore >= 5)
            {
                // Find the object you want to destroy by its name or tag
                GameObject objectToDestroy = GameObject.Find("collider"); // Replace with the actual name of the object
                if (objectToDestroy != null)
                {
                    Destroy(objectToDestroy);
                }
            }
            Destroy(gameObject);
        }
    }
}
