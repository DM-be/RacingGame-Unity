using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeTime : MonoBehaviour
{

    public int ModeSelection;
    public GameObject AICar;
    public static bool isTimeMode = false;
    public GameObject AmountLaps;
    public GameObject Place;

	// Use this for initialization
	void Start ()
	{
	    ModeSelection = ModeSelect.RaceMode;

	    switch (ModeSelection)
	    {
            case 2:
                isTimeMode = true;
                AICar.SetActive(false);
                AmountLaps.SetActive(false);
                Place.SetActive(false);
                break;
	    }
	}
}
