using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScore : MonoBehaviour {

    public int MyScore = 50;

	// Use this for initialization
    void OnTriggerEnter()
    {
        ModeScore.CurrentScore += MyScore;
        gameObject.SetActive(false);
    }
}
