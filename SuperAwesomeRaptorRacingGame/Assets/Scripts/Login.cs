
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Login : MonoBehaviour
{
   
    public class LoginDto {
        
        public string Username;
        public string Password;
    }

    public class BadRequestMessage {
        public string message;
    }

    public InputField userNameField;
    public InputField passwordField;
    public Text errorMessage;
    public Button loginButton;
    private const string URL = "http://localhost:50518/api/users/authenticate";

    void Start()
    {
        loginButton.onClick.AddListener(submitLogin);
    }

    public void submitLogin()
    {
        string userName = userNameField.text;
        string password = passwordField.text;
        if (userName != "" && password != "")
        {
            StartCoroutine(CallLogin(userName, password));
        }
    }

    public IEnumerator CallLogin(string Username, string Password) {

        LoginDto loginDto = new LoginDto();
        loginDto.Username = Username;
        loginDto.Password = Password;
        string jsonString = JsonUtility.ToJson(loginDto);
        UnityWebRequest www = UnityWebRequest.Put(URL, jsonString);
        www.method = "POST"; // For some reason UnityWebRequest applies URL encoding to POST message payloads. URL encoding the payload is an ASP.NET webform thing. 
        // see https://forum.unity.com/threads/unitywebrequest-post-url-jsondata-sending-broken-json.414708/ for more info
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        if (www.error != null) {
            byte[] result = www.downloadHandler.data;
            string badRequestJSON = System.Text.Encoding.Default.GetString(result);
            BadRequestMessage badRequestMessage = JsonUtility.FromJson<BadRequestMessage>(badRequestJSON);
            errorMessage.text = badRequestMessage.message;
        }
        else
        {
            Debug.Log("succes");
            // check the message --> if no users exists message --> clear fields 
            // else parse user object from backend
            byte[] result = www.downloadHandler.data;
            string userJSON = System.Text.Encoding.Default.GetString(result);
            UserManager.UserDto userDto = JsonUtility.FromJson<UserManager.UserDto>(userJSON);
            UserManager.Instance.User = userDto; // set main user variable in singleton class
            // navigate back to main
            SceneManager.LoadScene(4);

        }

    }


  

}
