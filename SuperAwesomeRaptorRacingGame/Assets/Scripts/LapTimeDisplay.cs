using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeDisplay : MonoBehaviour {

    public Text currentTime;
    public Text topPersonalTime;
    public Text topGlobalTime;

    private LapTimeManager LapTimeManager;

    // Use this for initialization
    void Start () {
		LapTimeManager = LapTimeManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
	    if (LapTimeManager.stopWatch.IsRunning)
	    {
	        currentTime.text = LapTimeManager.GetStopWatchFormattedTime();
	        topPersonalTime.text = LapTimeManager.GetTopPersonalTime();
            topGlobalTime.text = LapTimeManager.GetTopGlobalTime();
	    }
    }
}
