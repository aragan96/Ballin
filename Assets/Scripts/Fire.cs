using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	GameObject player;
	//Rigidbody playerrb;

	// Use this for initialization
	void Start () {
		//playerrb = GameObject.FindGameObjectWithTag ("Player").GetChild(2).GetComponent<Rigidbody>();
		player=GameObject.FindGameObjectWithTag("Player");
	}


	void OnCollisionEnter(Collision collision){
		
	}
	// Update is called once per frame
	void Update () {
		
		
	}

	//when hitting an obstacle (fire) 
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponentInParent<PlayerController> ().GoToCheckpoint();
			Destroy(player);
		}
	}

}
