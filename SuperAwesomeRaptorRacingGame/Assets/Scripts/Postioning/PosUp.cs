using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosUp : MonoBehaviour
{

    public GameObject postionDisplay;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CarPos")
        {
            postionDisplay.GetComponent<Text>().text = "1st Place";
        }
    }
}
