using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Flips the gravity when a player comes into contact with an object that has this script
 * */

public class FlipGravity : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") 
        {
            Physics.gravity *= -1;            
        }
    }
}
