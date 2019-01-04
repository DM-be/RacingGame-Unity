using UnityEngine;

public class UserManager : MonoBehaviour {

    public class UserObject
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }

    public static UserManager Instance { get; private set; }

    public UserObject User { get; set; }

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
