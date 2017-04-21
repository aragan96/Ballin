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
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward*1;

            // change the angle of the camera when you go through a portal

            /*
            Quaternion CameraRotation = Quaternion.LookRotation(otherPortal.transform.forward);
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            Vector3 offset = CameraRotation * new Vector3(0, 0, 1);
            camera.transform.position = other.transform.position + offset;
            camera.transform.rotation = Quaternion.LookRotation(other.transform.position - camera.transform.position, new Vector3(0, 1, 0));*/
        }
    }
}
