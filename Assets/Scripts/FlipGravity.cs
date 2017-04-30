using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") 
        {
            Physics.gravity *= -1;            
        }
    }
}
