using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    public GameObject LapTimeBox;
    public int LapsDone;

    public GameObject LapCounter;

    public GameObject RaceFinish;
    public int AmountOfLaps = 2;

    void Update()
    {
        Debug.unityLogger.Log(LapsDone);
        if (LapsDone >= AmountOfLaps)
        {
            RaceFinish.SetActive(true);
        }
    }

    void OnTriggerEnter()
    {
        LapsDone += 1;
        LapTimeTest.Instance.ResetStopwatch();
        // send best score in the reset 

        

        LapCounter.GetComponent<Text>().text = "" + LapsDone;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}
