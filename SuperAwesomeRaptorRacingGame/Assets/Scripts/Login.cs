﻿
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
   
    public class LoginDTO {
        
        public string Username;
        public string Password;
    }

    public InputField userNameField;
    public InputField passwordField;
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

        LoginDTO loginDTO = new LoginDTO();
        loginDTO.Username = Username;
        loginDTO.Password = Password;
        string jsonString = JsonUtility.ToJson(loginDTO);
        UnityWebRequest www = UnityWebRequest.Put(URL, jsonString);
        www.method = "POST"; // For some reason UnityWebRequest applies URL encoding to POST message payloads. URL encoding the payload is an ASP.NET webform thing. 
        // see https://forum.unity.com/threads/unitywebrequest-post-url-jsondata-sending-broken-json.414708/ for more info
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        if (www.error != null) {
            Debug.Log("error" + www.error);
        }
        else
        {
            Debug.Log("succes");
            // check the message --> if no users exists message --> clear fields 
            // else parse user object from backend
            byte[] result = www.downloadHandler.data;
            string userJSON = System.Text.Encoding.Default.GetString(result);
            Debug.Log(userJSON);
            UserManager.UserObject userObject = JsonUtility.FromJson<UserManager.UserObject>(userJSON);
            Debug.Log(userObject.Firstname);
            UserManager.Instance.User = userObject; // set main user variable in singleton class

            var user = UserManager.Instance.User;
            Debug.Log(user.Firstname);
            // navigate back to main

        }

    }


  

}
