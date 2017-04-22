using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha5)) 
        {
            Physics.gravity *= -1;
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

            camera.transform.Rotate(Vector3.forward, 180);

            // ...also rotate around the World's Y axis
           // transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
        }
    }
}
