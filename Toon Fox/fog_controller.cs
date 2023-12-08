using UnityEngine;
using System.Collections;

public class ParticleSystemController : MonoBehaviour
{
    new public ParticleSystem particleSystem;
    public float delayBeforeStart = 2.0f; // Delay before starting the Particle System.
    public float runDuration = 5.0f; // How long the Particle System will run initially.
    public float fadeOutDuration = 2.0f; // How long it takes to fade out the Particle System.
    public float timeBetweenRuns = 5.0f; // Time between each run.

    private void Start()
    {
        // Start the coroutine for controlling the Particle System.
        StartCoroutine(ControlParticleSystem());
    }

    private IEnumerator ControlParticleSystem()
    {
        while (true)
        {
            // Wait for the initial delay.
            yield return new WaitForSeconds(delayBeforeStart);

            // Start the Particle System.
            particleSystem.Play();

            // Wait for the specified run duration.
            yield return new WaitForSeconds(runDuration);

            // Slowly stop the Particle System by reducing the emission rate over the fadeOutDuration.
            var emission = particleSystem.emission;
            float initialRate = emission.rateOverTimeMultiplier;
            float timer = 0f;

            while (timer < fadeOutDuration)
            {
                float rate = Mathf.Lerp(initialRate, 0f, timer / fadeOutDuration);
                emission.rateOverTimeMultiplier = rate;
                timer += Time.deltaTime;
                yield return null;
            }

            // Stop the Particle System completely.
            particleSystem.Stop();

            // Wait for the specified time between runs.
            yield return new WaitForSeconds(timeBetweenRuns);
        }
    }
}
