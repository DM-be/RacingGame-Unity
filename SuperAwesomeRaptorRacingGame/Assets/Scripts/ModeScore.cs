using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeScore : MonoBehaviour
{

    public int ModeSelection;

    public GameObject RaceUI;
    public GameObject ScoreUI;
    public GameObject AICar;
    public GameObject ScoreValue;
    public GameObject ScorePoints;

    public static int CurrentScore;
    public int InternalScore;

	// Use this for initialization
	void Start ()
	{
	    ModeSelection = ModeSelect.RaceMode;

	    switch (ModeSelection)
	    {
            case 0:
                RaceUI.SetActive(true);
                ScoreUI.SetActive(false);
                ScorePoints.SetActive(false);
                break;
            case 1:
                AICar.SetActive(false);
                RaceUI.SetActive(false);
                ScoreUI.SetActive(true);
                ScorePoints.SetActive(true);
                break;
	    }
	}

    void Update()
    {
        InternalScore = CurrentScore;
        ScoreValue.GetComponent<Text>().text = "" + InternalScore;
    }
}
