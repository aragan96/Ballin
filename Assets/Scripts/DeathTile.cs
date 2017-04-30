using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player dies when comes into contact with an object with this script
 * */

public class DeathTile : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
            Physics.gravity = new Vector3(0,-Mathf.Abs(Physics.gravity.y),0);
			other.GetComponentInParent<PlayerController> ().GoToCheckpoint();
		}
	}
}
