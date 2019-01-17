using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UserManager : MonoBehaviour {



    // using camelcase here because of how the default mvc json is serialised
    [System.Serializable]
    public class UserDto
    {
        public int userId;
        public string username;
        public string firstName;
        public string lastName;
        public string token;
        public List<UserScoreDto> scores = new List<UserScoreDto> { };
    }
    [System.Serializable]
    public class UserScoreDto {
        public string trackName;
        public string time;
    }
    [System.Serializable]
    public class ScoreDto {
        public string username;
        public string firstName;
        public string lastName;
        public string trackName;
        public string time;
    }

    public static UserManager Instance { get; private set; }
    private const string scorePostURL = "http://localhost:50518/api/scores";

    public UserDto User;

    private void Awake()// called before start() --> get value of instance in other start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject); // destroy duplicates of UserManager
        }
    }

    public void SendLapTime(string Time) {
        StartCoroutine(CallSendScore(Time));
    }

    public IEnumerator CallSendScore(string Time) {
        ScoreDto scoreDto = new ScoreDto
        {
            username = User.username,
            firstName = User.firstName,
            lastName = User.lastName,
            trackName = SceneManager.GetActiveScene().name,
            time = Time,
        };

        string jsonString = JsonUtility.ToJson(scoreDto);
        UnityWebRequest www = UnityWebRequest.Put(scorePostURL, jsonString);
        www.method = "POST";

        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer " + User.token);
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }


    }

}
