using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

	// How far the door should slide on the x axis
	public float openDistance;
	public float speed;

    public bool closingDoor = false;

    // trigger to control opening
    public bool doorOpen;

    public bool doorClose = true;

    // where the door should end up at end of animation
    Vector3 targetPos;
	
	// Use this for initialization
	void Start () {
		targetPos = new Vector3 (transform.position.x + openDistance, transform.position.y, transform.position.z);
		doorOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (doorOpen) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetPos, step);
		}
        if (doorClose)
        {
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
