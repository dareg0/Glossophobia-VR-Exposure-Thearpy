using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerMinutes;
    public Text timerSeconds;
    public Text timerSeconds100;

    private float startTime;
    private float stopTime;
    private float timerTime;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        TimerReset();
    }

    public void TimerStart()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void TimerStop()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = timerTime;
        }
    }

    public void TimerReset()
    {
        isRunning = false;
        startTime = Time.time;
        stopTime = 0;
        timerMinutes.text = timerSeconds.text = timerSeconds100.text = "00";
    }

    private void Update()
    {
        timerTime = stopTime + (Time.time - startTime);
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;
        int seconds100Int = (int)(Mathf.Floor((timerTime - (secondsInt + minutesInt * 60)) * 100));

        if (isRunning)
        {
            timerMinutes.text = (minutesInt < 10) ? "0" + minutesInt: minutesInt.ToString();
            timerSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
            timerSeconds100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
        }
    }

    public string finishedTime()
    {
        string timeStr = "";
        if (!isRunning)
        {
            timeStr = timerMinutes.text + ":" + timerSeconds.text + ":" + timerSeconds100.text;
        }
        return timeStr;
    }
}
