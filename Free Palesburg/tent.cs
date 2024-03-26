using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tent : MonoBehaviour
{
    public float startingHealthTent = 100f;
    public float tenthealth;

    public Slider healthSlider;

    private bool isDissolving = false; // Flag to check if the dissolve effect is in progress

    public void Start()
    {
        tenthealth = startingHealthTent;
       
    }

    public void TakeDamageTent(float damagetent)
    {
        tenthealth -= damagetent;
        // Debug.Log("Tent health: " + tenthealth);
        

        if (tenthealth <= 0 && !isDissolving)
        {
            isDissolving = true; // Set the flag to indicate that dissolving is in progress
            DissolveMine dissolveScript = GetComponent<DissolveMine>(); // Get the DissolveMine script
            dissolveScript.startDissolver(); // Start the dissolve effect
            StartCoroutine(DestroyAfterDissolve(dissolveScript.dissolveDuration));
            
        }
    }

    private IEnumerator DestroyAfterDissolve(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        // Destroy the game object after the dissolve effect is complete
        Destroy(healthSlider.gameObject);
    }
    void Update()
    {
        
        
            healthSlider.value = tenthealth / startingHealthTent;
        
        
    }
}
