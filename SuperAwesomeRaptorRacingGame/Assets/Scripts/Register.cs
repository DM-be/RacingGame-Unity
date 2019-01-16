using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Register : MonoBehaviour {

    public class RegisterDto
    {
        public string FirstName;
        public string LastName;
        public string Username;
        public string Password;
    }
    public class BadRequestMessage
    {
        public string message;
    }

    public InputField LastNameField;
    public InputField FirstNameField;
    public InputField UserNameField;
    public InputField PasswordField;
    public Button RegisterButton;
    public Text ErrorMessage;

    private const string URL = "http://localhost:50518/api/users/register";

    void Start () {
        RegisterButton.onClick.AddListener(SubmitRegister);
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
            FirstName = FirstName,
            LastName = LastName,
            Password = Password,
            Username = Username
        };
        string jsonString = JsonUtility.ToJson(registerDto);
        Debug.Log(jsonString);
        UnityWebRequest www = UnityWebRequest.Put(URL, jsonString);
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            byte[] result = www.downloadHandler.data;
            string badRequestJSON = System.Text.Encoding.Default.GetString(result);
            BadRequestMessage badRequestMessage = JsonUtility.FromJson<BadRequestMessage>(badRequestJSON);
            ErrorMessage.text = badRequestMessage.message;
        }
        else
        {
            // navigate back to Login scene
            SceneManager.LoadScene(2);
        }
    }

}
