﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCar : MonoBehaviour
{
    //TODO enum
    public static int CarType; // 0 = Red, 1 = Blue, 2 = Green
    public GameObject TrackWindow;

    public void RedCar()
    {
        CarType = 0;
        TrackWindow.SetActive(true);
    }

    public void BlueCar()
    {
        CarType = 1;
        TrackWindow.SetActive(true);
    }

    public void GreenCar()
    {
        CarType = 2;
        TrackWindow.SetActive(true);
    }
}
