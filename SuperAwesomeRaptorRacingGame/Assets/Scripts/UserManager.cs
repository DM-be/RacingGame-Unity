using UnityEngine;

public class UserManager : MonoBehaviour {

    public class UserObject
    {
        public int userId;
        public string username;
        public string firstName;
        public string lastName;
        public string token;
    }

    public static UserManager Instance { get; private set; }

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
    


}
