﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlate : MonoBehaviour {

	public float bouncePower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponentInParent<PlayerController> ().Bounce (bouncePower);
		}
	}
}
