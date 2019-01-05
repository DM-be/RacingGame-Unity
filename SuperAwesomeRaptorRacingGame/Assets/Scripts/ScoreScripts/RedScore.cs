using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScore : MonoBehaviour {

    public int MyScore = 100;

	// Use this for initialization
    void OnTriggerEnter()
    {
        ModeScore.CurrentScore += MyScore;
        gameObject.SetActive(false);
    }
}
