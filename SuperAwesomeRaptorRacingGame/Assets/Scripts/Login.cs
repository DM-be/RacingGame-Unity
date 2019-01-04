
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public Button loginButton;

    void Start()
    {
        loginButton.onClick.AddListener(submitLogin);
    }


    
    public void submitLogin()
    {
        string userName = userNameField.text;
        string password = passwordField.text;
        
       Debug.Log(userName);
        Debug.Log(password);


    }

}
