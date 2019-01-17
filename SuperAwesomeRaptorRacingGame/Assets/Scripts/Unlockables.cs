using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlockables : MonoBehaviour
{

    public GameObject greenButton;
    public int greenCarPrice = 100;

    public int cashValue;

	void Update ()
	{
	    cashValue = GlobalCash.TotalCash;

	    if (cashValue >= greenCarPrice)
	    {
	        greenButton.GetComponent<Button>().interactable = true;
	    }
	}

    public void GreenUnlock()
    {
        greenButton.SetActive(false);

        cashValue -= greenCarPrice;

        GlobalCash.TotalCash -= greenCarPrice;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
        PlayerPrefs.SetInt("GreenBought", greenCarPrice);
    }
}
