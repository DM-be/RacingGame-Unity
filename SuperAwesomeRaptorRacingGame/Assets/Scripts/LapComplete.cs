using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public int LapsDone;

    public GameObject LapCounter;

    public GameObject RaceFinish;
    public int AmountOfLaps = 2;

    void Update()
    {
        if (LapsDone >= AmountOfLaps)
        {
            RaceFinish.SetActive(true);
        }
    }

    void OnTriggerEnter()
    {
        LapsDone += 1;
        UserManager.Instance.SendLapTime(LapTimeManager.Instance.GetStopWatchFormattedTime());
        LapTimeManager.Instance.AddLapToUserScores();
        LapTimeManager.Instance.ResetStopwatch();

        if (LapsDone <= AmountOfLaps)
        {
            LapCounter.GetComponent<Text>().text = "" + LapsDone;
        }

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}
