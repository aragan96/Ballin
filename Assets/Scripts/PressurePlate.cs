using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    //the door that the plate will open
	public SlidingDoor doorToOpen;

    //the minimum weight to open the door
	public float weightThreshold;

    // if the plate should change color when the door opens
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

        //If the player leaves the door and there is nothing else on the plate then close the door
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

        //If the player or a doorkey is placed on the pressure plate open the door
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
