using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public SlidingDoor doorToOpen;
	public float weightThreshold;
    public bool colorChanging = true;

	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider> ().isTrigger = true;
        if (colorChanging)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
	}

    void OnTriggerExit(Collider other)
    {
            if (doorToOpen.closingDoor && doorToOpen.doorOpen)
            {
                doorToOpen.CloseDoor();
                if (colorChanging)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            }   
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponentInParent<PlayerController>().size >= weightThreshold)
            {
                doorToOpen.OpenDoor();
                if (colorChanging)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
        else
        {
            if (other.transform.localScale.x >= weightThreshold)
            {
                doorToOpen.OpenDoor();
                if (colorChanging)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }
}
