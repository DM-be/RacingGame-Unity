using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class LapTimeManager : MonoBehaviour {

    public Text currentTime;
    public Text topPersonalTime;
    public Text topGlobalTime;
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

    void Update() {
        if (stopWatch.IsRunning)
        {
            currentTime.text = FormatTimeSpan(stopWatch.Elapsed);
            topPersonalTime.text = GetTopPersonalTime();
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

    public string GetTopPersonalTime() {
        // top score is always first returned (ordered by backend)
        if (UserManager.Instance.User.scores.Count > 0)
        {
            return UserManager.Instance.User.scores[0].time;
        }
        return "00:00:0000";
        
    }

    public void SetTopGlobalTime() {


        // call from backend the top time of this scene
    }


    private void OrderPersonalTimes() {
        UserManager.Instance.User.scores.Sort((a,b) => a.time.CompareTo(b.time));
    }

    public void AddLapToUserScores() {
        UserManager.Instance.User.scores.Add(new UserManager.UserScoreDto { time = GetStopWatchFormattedTime(), trackName = SceneManager.GetActiveScene().name });
        OrderPersonalTimes();
    }
}
