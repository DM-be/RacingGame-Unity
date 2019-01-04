using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void SelectTrack()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadLoginScene() {

        SceneManager.LoadScene(5);
    }

    public void loadRegisterScene() {
        SceneManager.LoadScene(6);

    }




    //Below here are track selection buttons
    public void Track01()
    {
        SceneManager.LoadScene(2);
    }

    public void Track02()
    {
        SceneManager.LoadScene(3);
    }
}
