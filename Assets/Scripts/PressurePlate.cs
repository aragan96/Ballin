using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public SlidingDoor doorToOpen;
	public float weightThreshold;

	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider> ().isTrigger = true;
		GetComponent<Renderer> ().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (other.GetComponentInParent<PlayerController> ().size >= weightThreshold) {
				doorToOpen.OpenDoor ();
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
				// gameObject.GetComponent<BoxCollider> ().enabled = false;
			}
		}
        else
        {
            if(other.transform.localScale.x>= weightThreshold)
            {
                doorToOpen.OpenDoor();
                gameObject.GetComponent<Renderer>().material.color = Color.red;
               // gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
	}

    void OnTriggerExit (Collider other)
    {
        Debug.Log("hi");
        if (doorToOpen.closingDoor && doorToOpen.doorOpen)
        {
            doorToOpen.CloseDoor();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
          //  gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
