using UnityEngine;

public class SoundEffectTrigger : MonoBehaviour
{
    public GameObject flame;

    private void Start()
    {
        flame.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Make sure to set the appropriate tag for your player GameObject
        {
            flame.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        { flame.SetActive(false); }
    }
}
