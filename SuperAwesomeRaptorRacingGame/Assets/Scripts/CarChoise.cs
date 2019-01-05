using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoise : MonoBehaviour
{

    public GameObject RedBody;
    public GameObject BlueBody;
    public GameObject GreenBody;
    public int CarImport;

	void Start ()
	{
	    CarImport = GlobalCar.CarType;
        //TODO enum
	    switch (CarImport)
	    {
            case 0:
                RedBody.SetActive(true);
                break;
            case 1:
                BlueBody.SetActive(true);
                break;
            case 2:
                GreenBody.SetActive(true);
                break;
	    }
	}

}
