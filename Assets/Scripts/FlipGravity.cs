using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour {

	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            Physics.gravity *= -1;
        }
    }
}
