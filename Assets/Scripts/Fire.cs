using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	//GameObject player;
	//Rigidbody playerrb;

	// Use this for initialization
	void Start () {
		//playerrb = GameObject.FindGameObjectWithTag ("Player").GetChild(2).GetComponent<Rigidbody>();

		//player=GameObject.FindGameObjectWithTag("Player");
	}
	void Update () {

	}


	void OnParticleCollision(GameObject player){
		Debug.Log ("hit fire");
			Rigidbody body = player.GetComponent<Rigidbody>();
			if (body) {
			
				player.GetComponentInParent<PlayerController> ().GoToCheckpoint ();
				Destroy (player);
			}
		}
	}
	// Update is called once per frame



	


