using UnityEngine;

public class WaterSound : MonoBehaviour
{
    public GameObject water;

    private void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Make sure to set the appropriate tag for your player GameObject
        {
            water.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { water.SetActive(false); }
    }
}
