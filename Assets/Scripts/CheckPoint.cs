using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponentInParent<PlayerController> ().SaveCheckpoint (transform.position);
			gameObject.GetComponent<Renderer> ().material.color = Color.green;

		}
	}

	

}
