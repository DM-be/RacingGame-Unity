using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowScore : MonoBehaviour {

    public int MyScore = 25;

    // Use this for initialization
    void OnTriggerEnter()
    {
        ModeScore.CurrentScore += MyScore;
        gameObject.SetActive(false);
    }
}
