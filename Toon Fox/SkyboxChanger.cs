using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkyboxChanger : MonoBehaviour
{
    public Material skyboxMaterial1;
    public Material skyboxMaterial2;
    public Toggle toggle;

    private Material currentSkybox;

    private void Start()
    {
        currentSkybox = skyboxMaterial1;
        RenderSettings.skybox = currentSkybox;

        // Attach a listener to the toggle's state change event.
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool newValue)
    {
        // Check the toggle's state and update the skybox accordingly.
        if (newValue)
        {
            currentSkybox = skyboxMaterial2;
        }
        else
        {
            currentSkybox = skyboxMaterial1;
        }

        RenderSettings.skybox = currentSkybox;
    }
}
