using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosDown : MonoBehaviour {

    public GameObject postionDisplay;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CarPos")
        {
            postionDisplay.GetComponent<Text>().text = "2nd Place";
        }
    }

}
