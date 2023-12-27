using UnityEngine;
using UnityEngine.UI;

public class ButtonPressScript : MonoBehaviour
{
    public GoogleMobileAdsDemoScript adScript;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonPress);
    }

    private void OnButtonPress()
    {
        adScript.showAdOnButtonPress = true;
    }
}
