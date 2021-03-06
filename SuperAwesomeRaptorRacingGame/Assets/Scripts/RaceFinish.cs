﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class RaceFinish : MonoBehaviour
{

    public GameObject MyCar;
    public GameObject FinishCam;
    public GameObject ViewModes;
    public GameObject LevelMusic;
    public GameObject CompleteTrigger;
    public LapTimeManager LapTimeManager;

    void OnTriggerEnter(Collider other)
    {
        if (!ModeTime.isTimeMode && other.tag == "PlayerCar")
        {

            LapTimeManager = LapTimeManager.Instance;
            LapTimeManager.StopStopwatch();
            this.GetComponent<BoxCollider>().enabled = false;
            MyCar.SetActive(false);
            CompleteTrigger.SetActive(false);
            CarController.m_Topspeed = 0.0f;
            MyCar.GetComponent<CarController>().enabled = false;
            MyCar.GetComponent<CarUserControl>().enabled = false;

            MyCar.SetActive(true);
            FinishCam.SetActive(true);
            LevelMusic.SetActive(false);
            ViewModes.SetActive(false);

            GlobalCash.TotalCash += 100;
            PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);

            StartCoroutine(ToMenu());
        }
 
    }

    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }

}
