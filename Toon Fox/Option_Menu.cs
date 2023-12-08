using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QualitySettingsDropdown : MonoBehaviour
{
    public Dropdown qualityDropdown;

    private void Start()
    {
        // Populate the dropdown with quality levels
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(QualitySettings.names.ToList());

        // Set the current quality level as the default selection
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();

        // Add a listener to the dropdown to handle changes
        qualityDropdown.onValueChanged.AddListener(ChangeQualityLevel);
    }

    private void ChangeQualityLevel(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
