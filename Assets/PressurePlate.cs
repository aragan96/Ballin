using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public SlidingDoor doorToOpen;

	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider> ().isTrigger = true;
		GetComponent<Renderer> ().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			doorToOpen.OpenDoor ();
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		Debug.Log (other.tag);
	}
}
