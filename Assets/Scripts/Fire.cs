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
		if (other.tag == "Player") {
			player.GetComponentInParent<PlayerController> ().GoToCheckpoint ();
			Destroy (player);
		}
	}
	// Update is called once per frame
	void Update () {
		
		
	}


	}


