using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public GameObject NormalCam;
    public GameObject FarCam;
    public GameObject FPCam;
    //TODO statics of CamMode, eleminate magic numbers
    public int CamMode;

	void Update () {
	    if (Input.GetButtonDown("ViewMode"))
	    {
	        CamMode += 1;
            CamMode %= 3;
	        StartCoroutine(ModeChange());
	    }
	}

    IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        switch (CamMode)
        {
            case 0:
                NormalCam.SetActive(true);
                FPCam.SetActive(false);
                break;
            case 1:
                FarCam.SetActive(true);
                NormalCam.SetActive(false);
                break;
            case 2:
                FPCam.SetActive(true);
                FarCam.SetActive(false);
                break;
        }
    }
}
