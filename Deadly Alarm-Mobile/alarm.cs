using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class AlarmClock : MonoBehaviour
{
    public AudioClip alarmSound;
    private AudioSource audioSource; // Reference to the AudioSource
    public Text alarmTimeText;
    public Text currentTimeText;
    public InputField inputField;
    public GameObject game;
    public GameObject clocker;
    private bool alarmTriggered = false;
    private DateTime alarmTime;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        game.SetActive(false);
        clocker.SetActive(true);
     alarmTriggered = false;

    // Set a default alarm time
    SetAlarmTime(0, 0);
    }

    void Update()
    {
        // Update the current time text
        currentTimeText.text = "Current Time: " + GetCurrentTime();

        if (!alarmTriggered && DateTime.Now >= alarmTime)
        {
            // Trigger the alarm
            PlayAlarm();
            alarmTriggered = true;
            clocker.SetActive(false);
            
        }
    }

    void PlayAlarm()
    {
        // Play the alarm sound
        audioSource.PlayOneShot(alarmSound);
        game.SetActive(true);
    }

    string GetCurrentTime()
    {

        return DateTime.Now.ToString("HH:mm:ss");
    }

    void SetAlarmTime(int hours, int minutes)
    {
        DateTime now = DateTime.Now;

        DateTime alarmDateTime = new DateTime(now.Year, now.Month, now.Day, hours, minutes, 0);

        if (now > alarmDateTime)
        {
            alarmDateTime = alarmDateTime.AddDays(1);
        }

        alarmTime = alarmDateTime;

        alarmTimeText.text = "Alarm Time: " + alarmTime.ToString("HH:mm");
    }


    public void OnSetAlarmButtonPressed()
    {
        if (DateTime.TryParseExact(inputField.text, "HH:mm", null, DateTimeStyles.None, out DateTime parsedTime))
        {
            SetAlarmTime(parsedTime.Hour, parsedTime.Minute);
        }
        else
        {
            Debug.LogError("Invalid time format. Use HH:mm (24-hour format).");
        }
    }
}
