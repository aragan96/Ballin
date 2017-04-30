using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Bounces the player up at a customizable speed 
 * */

public class BouncePlate : MonoBehaviour {

	public float bouncePower;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponentInParent<PlayerController> ().Bounce (bouncePower);
		}
	}
}
