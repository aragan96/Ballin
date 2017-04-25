using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour {

    GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            Physics.gravity *= -1;

            // rotate the camera
            camera.GetComponent<RightAngleCam>().upVector = camera.GetComponent<RightAngleCam>().upVector * -1;
            camera.GetComponent<RightAngleCam>().orbitDegreesPerSec = camera.GetComponent<RightAngleCam>().orbitDegreesPerSec * -1;

            camera.transform.localPosition = new Vector3(100, 100, 100);

            camera.GetComponent<CameraController>().upVector = camera.GetComponent<CameraController>().upVector * -1;
            
        }
    }
}
