using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{
    public GameObject CountDownObject;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControl;
    public AudioSource LevelMusic;



    void Awake() {
        
    }


    void Start ()
	{
	    StartCoroutine(CountStart());
	}

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDownObject.GetComponent<Text>().text = "3";
        GetReady.Play();
        CountDownObject.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownObject.SetActive(false);
        CountDownObject.GetComponent<Text>().text = "2";
        GetReady.Play();
        CountDownObject.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownObject.SetActive(false);
        CountDownObject.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDownObject.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownObject.SetActive(false);
        GoAudio.Play();
        LapTimeTest.Instance.StartStopwatch();
        CarControl.SetActive(true);

        LevelMusic.Play();
    }
}
