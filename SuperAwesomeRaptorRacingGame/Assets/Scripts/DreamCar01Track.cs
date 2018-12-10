using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCar01Track : MonoBehaviour
{

    public GameObject TheMarker;
    public GameObject Marker01;
    public GameObject Marker02;
    public GameObject Marker03;
    public GameObject Marker04;
    public GameObject Marker05;
    public GameObject Marker06;
    public GameObject Marker07;
    public GameObject Marker08;
    public GameObject Marker09;
    public GameObject Marker10;
    public int MarkTracker;

    public GameObject[] MarkerArray;

    void Start()
    {
        MarkerArray = new[]
        {
            Marker01,
            Marker02,
            Marker03,
            Marker04,
            Marker05,
            Marker06,
            Marker07,
            Marker08,
            Marker09,
            Marker10,
        };
    }

    void Update ()
    {
        GameObject Marker = MarkTracker2MarkObject(MarkTracker);
  
        TheMarker.transform.position = Marker.transform.position;
	}

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "DreamCar01")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            MarkTracker += 1;
            MarkTracker %= MarkerArray.Length;

            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }

    GameObject MarkTracker2MarkObject(int markTrackerNumber)
    {
        return MarkerArray[markTrackerNumber];
    }
}
