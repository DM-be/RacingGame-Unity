using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;

public class LapTimeManager : MonoBehaviour {

    public Stopwatch stopWatch;

    public static LapTimeManager Instance { get; private set; }
    private string topGlobalTime;


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
        UpdateTopGlobalTime();
    }

    public void StartStopwatch() {
        stopWatch.Start();
    }

    public void StopStopwatch()
    {
        stopWatch.Stop();
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
            return UserManager.Instance.User.scores.Where(sc => sc.trackName == SceneManager.GetActiveScene().name).First().time;
        }
        return "00:00:00";
        
    }

    public string GetTopGlobalTime() {
        if (topGlobalTime == null)
        {
            return "00:00:00";
        }
        return topGlobalTime;
    }

    public void UpdateTopGlobalTime() {
        StartCoroutine(SendRequestAndUpdateGlobalTime());
    }

  
    public IEnumerator SendRequestAndUpdateGlobalTime() {
        var URL = "http://localhost:50518/api/scores/top/" + SceneManager.GetActiveScene().name;
        UnityWebRequest www = UnityWebRequest.Get(URL);
        www.SetRequestHeader("Authorization", "Bearer " + UserManager.Instance.User.token);
        yield return www.SendWebRequest();
        if (www.error != null) {
        }
        else {
            byte[] result = www.downloadHandler.data;
            topGlobalTime =  System.Text.Encoding.Default.GetString(result);
        }
    }


    private void OrderPersonalTimes() {
        UserManager.Instance.User.scores.Sort((a,b) => a.time.CompareTo(b.time));
    }

    public void AddLapToUserScores() {
        UserManager.Instance.User.scores.Add(new UserManager.UserScoreDto { time = GetStopWatchFormattedTime(), trackName = SceneManager.GetActiveScene().name });
        OrderPersonalTimes();
    }
}
