using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
            Physics.gravity = new Vector3(0,-Mathf.Abs(Physics.gravity.y),0);
            Debug.Log(Physics.gravity);
			other.GetComponentInParent<PlayerController> ().GoToCheckpoint();
		}
	}
}
