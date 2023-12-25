using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ColorMatcher : MonoBehaviour
{
    public Text feedbackText;
    public Text scoreText;
    public Button checkButton;
    public Image targetColorImage;
    public Toggle[] colorToggles;

    private Color targetColor;
    private Color[] randomColors;
    public AudioSource audioSource;
    private List<int> selectedIndices = new List<int>();
    private int score = 0;

    void Start()
    {
        NewRound(); // Start a new round

        checkButton.onClick.AddListener(CheckColorCombination);


        for (int i = 0; i < colorToggles.Length; i++)
        {
            int index = i;
            colorToggles[i].onValueChanged.AddListener((value) => ToggleValueChanged(index, value));
        }
    }

    void NewRound()
    {
        SetRandomTargetColor();
        SetRandomColors();
        UpdateFeedbackText("Select three colors and press Submit.");

        foreach (Toggle toggle in colorToggles)
        {
            toggle.isOn = false;
        }
    }

    void SetRandomTargetColor()
    {

        targetColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);

        targetColorImage.color = targetColor;
    }

    void SetRandomColors()
    {

        randomColors = new Color[5];

        float targetR = targetColor.r;
        float targetG = targetColor.g;
        float targetB = targetColor.b;

        randomColors[0] = new Color(targetR, 0f, 0f); // Red 
        randomColors[1] = new Color(0f, targetG, 0f); // Green 
        randomColors[2] = new Color(0f, 0f, targetB); // Blue 

        // Generate two more random colors
        for (int i = 3; i < 5; i++)
        {
            randomColors[i] = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }

        ShuffleArray(randomColors);

        for (int i = 0; i < colorToggles.Length; i++)
        {
            ColorBlock colors = colorToggles[i].colors;
            colors.normalColor = randomColors[i];
            colorToggles[i].colors = colors;
        }
    }

    void ShuffleArray<T>(T[] array)
    {
        // Fisher-Yates shuffle algorithm
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }


    void ToggleValueChanged(int index, bool value)
    {
        if (value)
        {
            selectedIndices.Add(index);
        }
        else
        {
            selectedIndices.Remove(index);
        }
        UpdateSelectedColorsUI();
    }

    void UpdateSelectedColorsUI()
    {
        for (int i = 0; i < colorToggles.Length; i++)
        {
            ColorBlock colors = colorToggles[i].colors;

            if (selectedIndices.Contains(i))
            {

                colors.normalColor = Color.gray; 
            }
            else
            {
                colors.normalColor = randomColors[i];
            }

            colorToggles[i].colors = colors;
        }
    }

    void CheckColorCombination()
    {
        if (selectedIndices.Count != 3)
        {
            UpdateFeedbackText("Please select exactly three colors.");
            return;
        }

        selectedIndices.Sort();

        Color combinedColor = randomColors[selectedIndices[0]] +
                              randomColors[selectedIndices[1]] +
                              randomColors[selectedIndices[2]];

        if (ColorCloseEnough(combinedColor, targetColor))
        {
            UpdateFeedbackText("Success! Color combination is correct.");
            score++;
            UpdateScoreText();
            StartCoroutine(ResetAndHideSuccessMessage());
        }
        else
        {
            UpdateFeedbackText("Try again. Color combination is incorrect.");
            score--;
            UpdateScoreText();
        }
    }


    void ResetSelectedIndices()
    {
        selectedIndices.Clear();

        UpdateSelectedColorsUI();
    }

    void UpdateFeedbackText(string message)
    {
        feedbackText.text = message;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    bool ColorCloseEnough(Color a, Color b, float threshold = 0.1f)
    {
        // Check if the RGB values are close enough
        return Mathf.Abs(a.r - b.r) < threshold &&
               Mathf.Abs(a.g - b.g) < threshold &&
               Mathf.Abs(a.b - b.b) < threshold;
    }

    IEnumerator ResetAndHideSuccessMessage()
    {
        checkButton.interactable = false;

        yield return new WaitForSeconds(2f);

        checkButton.interactable = true;

        NewRound();
    }
    private void Update()
    {
        if(score >= 5) 
        {
                    audioSource.Pause();
        }
    }
}
