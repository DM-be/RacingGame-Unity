using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class LapTimeManager : MonoBehaviour {

    public Text newTime;
    public Stopwatch stopWatch;

    public static LapTimeManager Instance { get; private set; }


    private void Awake()// called before start() --> get value of instance in other start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // destroy duplicates of LapTimeManager
        }
    }

    private void Start()
    {
        stopWatch = new Stopwatch();
    }

    void Update () {
        if (stopWatch.IsRunning)
        {
            newTime.text = FormatTimeSpan(stopWatch.Elapsed);
        }
    }

    public void StartStopwatch() { 
        stopWatch.Start();
    }

    public void ResetStopwatch() {
        stopWatch.Stop();
        stopWatch.Reset();
        stopWatch.Start();
    }

    private string FormatTimeSpan(TimeSpan timeSpan)
    {
        return String.Format("{0:00}:{1:00}.{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }

    public string GetStopWatchFormattedTime() {
        return FormatTimeSpan(stopWatch.Elapsed);
    }

}
