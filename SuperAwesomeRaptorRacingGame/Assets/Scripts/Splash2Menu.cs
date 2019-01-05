using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash2Menu : MonoBehaviour {

    void Start()
    {
        StartCoroutine(ToMenu());
    }

    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(4);
        //TODO correct screen
        //SceneManager.LoadScene(1);
    }
}
