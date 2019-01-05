using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class LapTimeTest : MonoBehaviour {

    public Text newTime;
    public Stopwatch stopWatch;

    public static LapTimeTest Instance { get; private set; }


    private void Awake()// called before start() --> get value of instance in other start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // destroy duplicates of UserManager
        }
    }

    private void Start()
    {
        stopWatch = new Stopwatch();
    }

    void Update () {
        if (stopWatch.IsRunning)
        {
            newTime.text = FormatMilliSeconds(stopWatch.ElapsedMilliseconds);
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

    string FormatMilliSeconds(float elapsed)
    {
        int d = (int)(elapsed/1000 * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;
        return String.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}
