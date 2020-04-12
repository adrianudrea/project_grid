using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    [Header("Components")]
    public ResourceManager resourceManager;
    public Text currentTime;
    public Text currentDayText;
    public Light sunLight;
    public Button pauseButton;
    public Button resumeButton;
    public Button fastButton;
    [Header("Values")]
    public int currentDay;
    public int currentHour;
    public int currentMinute;
    public int currentSecond;
    [Header("Bools")]
    public bool hasCurrentHourChanged;

    private void Start()
    {
        sunLight.intensity = 1.0f;

        ButtonFunctionality();
    }

    private void FixedUpdate()
    {
        TimeControl();
        LightControl();
    }

    public void PauseGame()             { Time.timeScale = 0.1f; }
    public void ResumeGame()            { Time.timeScale = 1.0f; }
    public void GameSpeedTwoX()         { Time.timeScale = 3.0f; }

    private void ButtonFunctionality()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        fastButton.onClick.AddListener(GameSpeedTwoX);
    }

    private void TimeControl()
    {
        currentTime.text = currentHour.ToString() + " : " + currentMinute.ToString();
        currentDayText.text = "DAY " + currentDay.ToString();
        currentSecond++;

        if(currentSecond == 60)
        {
            currentSecond = 0;
            currentMinute++;
        }
        if(currentMinute == 60)
        {
            currentMinute = 0;
            currentHour++;
            hasCurrentHourChanged = true;

            if(hasCurrentHourChanged)
            {
                resourceManager.GetComponent<ResourceManager>().GiveResources();
                hasCurrentHourChanged = false;
            }
        }
        if(currentHour == 24)
        {
            currentHour = 0;
            currentDay++;
        }
    }

    private void LightControl()
    {
        if(currentHour == 18)
        {
            sunLight.intensity = 0.5f;
        }
        else if(currentHour == 20)
        {
            sunLight.intensity = 0.1f;
        }
        else if(currentHour == 5)
        {
            sunLight.intensity = 0.3f;
        }
        else if(currentHour == 7)
        {
            sunLight.intensity = 0.5f;
        }
        else if(currentHour == 9)
        {
            sunLight.intensity = 1.0f;
        }
    }
}
