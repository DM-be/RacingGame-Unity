using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {

    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public InputField LastNameField;
    public InputField FirstNameField;
    public InputField UserNameField;
    public InputField PasswordField;
    public Button LoginButton;
    private const string URL = "http://localhost:50518/api/users/register";

    void Start () {
        LoginButton.onClick.AddListener(SubmitRegister);
    }


    void SubmitRegister() {
        string Username = UserNameField.text;
        string Password = PasswordField.text;
        string FirstName = FirstNameField.text;
        string LastName = LastNameField.text;

        if (Username != "" && Password != "" && FirstName != "" && LastName != "")
        {
            StartCoroutine(CallRegister(Username, Password, FirstName, LastName));
        }

    }

    public IEnumerator CallRegister(string Username, string Password, string FirstName, string LastName ) {
        RegisterDto registerDto = new RegisterDto
        {
            Username = Username,
            Password = Password,
            FirstName = FirstName,
            LastName = LastName
        };
        string jsonString = JsonUtility.ToJson(registerDto);
        UnityWebRequest www = UnityWebRequest.Put(URL, jsonString);
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            Debug.Log("error" + www.error);
        }
        else
        {
            // navigate back to Login scene
            SceneManager.LoadScene(0);

        }


    }

}
