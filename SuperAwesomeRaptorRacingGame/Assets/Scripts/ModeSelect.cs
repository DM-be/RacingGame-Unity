using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    //TODO enum
    public static int RaceMode;  // 0 = Race, 1 = Score, 2 = Time
    public GameObject ToShow;

    public void ScoreMode()
    {
        RaceMode = 1;
        ToShow.SetActive(true);
    }

    public void TimeMode()
    {
        RaceMode = 2;
        ToShow.SetActive(true);
    }

    public void RaceModeSelect()
    {
        RaceMode = 0;
        ToShow.SetActive(true);
    }
}
