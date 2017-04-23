using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            Physics.gravity *= -1;
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

            // rotate the camera
            camera.GetComponent<CameraController>().upVector = camera.GetComponent<CameraController>().upVector * -1;
        }
    }
}
