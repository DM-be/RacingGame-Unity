using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour {

    /*public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    */
    public void PlayGame()
    {
        SceneManager.LoadScene(5);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void loadLoginScene() {

        SceneManager.LoadScene(2);
    }

    public void loadRegisterScene() {
        SceneManager.LoadScene(3);

    }


    public void Credits()
    {
        SceneManager.LoadScene(8);
    }

    //Below here are track selection buttons
    public void Track01()
    {
        SceneManager.LoadScene(6);
    }

    public void Track02()
    {
        SceneManager.LoadScene(7);
    }
}
