using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Records the position of the player in the case of player death
 * */

public class CheckPoint : MonoBehaviour {
    
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponentInParent<PlayerController> ().SaveCheckpoint (transform.position);
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
	}
}
