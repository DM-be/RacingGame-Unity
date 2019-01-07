using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UserManager : MonoBehaviour {

    public class UserObject
    {
        public int userId;
        public string username;
        public string firstName;
        public string lastName;
        public string token;
    }

    public class ScoreDto {
        public string Username;
        public string FirstName;
        public string LastName;
        public string TrackName;
        public string Time;
    }

    public static UserManager Instance { get; private set; }
    private const string scorePostURL = "http://localhost:50518/api/scores";

    public UserObject User;

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
            Username = User.username,
            FirstName = User.firstName,
            LastName = User.lastName,
            TrackName = SceneManager.GetActiveScene().name,
            Time = Time,
        };
        string jsonString = JsonUtility.ToJson(scoreDto);
        Debug.Log(jsonString);
        UnityWebRequest www = UnityWebRequest.Put(scorePostURL, jsonString);
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }


    }

}
