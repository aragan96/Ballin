using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Opens and closes a sliding door from a start position to a target position
 * */

public class SlidingDoor : MonoBehaviour {

	// How far the door should slide on the x axis
	public float openDistance;
	public float speed;

	// trigger to control opening
	public bool doorOpen;
    public bool doorClose = true;

    // if the door should automatically close or not 
    public bool closingDoor = false;

	// where the door should end up at end of animation
	Vector3 targetPos;
	Vector3 startPos;
	
	// Use this for initialization
	void Start () { 
		startPos = transform.position;
		targetPos = new Vector3 (transform.position.x + openDistance, transform.position.y, transform.position.z);
		doorOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (doorOpen) {
            
            //Open the door if player opens with pressure pad
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetPos, step);
		}
        if (doorClose)
        {
     
            //return door to start position
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
	}

	public void OpenDoor(){
		doorOpen = true;
        doorClose = false;
	}
			
    public void CloseDoor()
    {
        doorOpen = false;
        doorClose = true;
    }
}
