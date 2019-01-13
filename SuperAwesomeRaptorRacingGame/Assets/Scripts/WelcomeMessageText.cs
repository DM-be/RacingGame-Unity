using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMessageText : MonoBehaviour {

	public Text welcomeText;

    void start() {
        welcomeText.text = UserManager.Instance.User.firstName;
        Debug.Log(welcomeText.text);
        Debug.Log(UserManager.Instance.User.firstName);
    }

    private void Update()
    {
        if (UserManager.Instance.User != null)
        {
         welcomeText.text = UserManager.Instance.User.firstName;
        }
        
    }
}
