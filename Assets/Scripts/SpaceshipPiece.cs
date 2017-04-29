using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipPiece : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			GameManager.instance.stagesComplete [GameManager.instance.currentStage] = true;
			SceneManager.LoadScene ("Lobby");
		}
	}
}
