using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour {

    public GameObject otherPortal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward*1f;

            // change the angle of the camera when you go through a portal         
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.transform.position = other.transform.position + otherPortal.transform.forward*0.1f;
            camera.transform.rotation = Quaternion.LookRotation(other.transform.position - camera.transform.position);
        }
    }
}
