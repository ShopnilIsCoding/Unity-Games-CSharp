using UnityEngine;
using UnityEngine.Playables;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera timelineCamera;
    public PlayableDirector timelineDirector;

    private bool timelineFinished = false;

    private void Start()
    {
        // Ensure the main camera is enabled at the start
        EnableMainCamera();
    }

    private void Update()
    {
        // Check if the Timeline is finished
        if (timelineDirector != null )
        {
            // Switch back to the main camera
            EnableMainCamera();
            timelineFinished = false; // Reset the flag
        }
    }

    public void PlayTimeline()
    {
        // Disable the main camera and enable the timeline camera
        DisableMainCamera();
        EnableTimelineCamera();

        // Play the timeline
        if (timelineDirector != null)
        {
            timelineDirector.Play();
            timelineFinished = false; // Reset the flag
        }
    }

    // Function to enable the main camera
    private void EnableMainCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.enabled = true;
        }
    }

    // Function to disable the main camera
    private void DisableMainCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.enabled = false;
        }
    }

    // Function to enable the timeline camera
    private void EnableTimelineCamera()
    {
        if (timelineCamera != null)
        {
            timelineCamera.enabled = true;
        }
    }

    // Function to disable the timeline camera
    private void DisableTimelineCamera()
    {
        if (timelineCamera != null)
        {
            timelineCamera.enabled = false;
        }
    }

    // Called by the Timeline to mark it as finished
    public void OnTimelineFinished()
    {
        timelineFinished = true;
    }
}
