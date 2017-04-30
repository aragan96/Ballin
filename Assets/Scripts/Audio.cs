using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Plays audio at the startup of the game, music plays continuously throughout gameplay
 * */

public class Audio:MonoBehaviour{

	void Awake() {
		GameObject [] objs = GameObject.FindGameObjectsWithTag ("music");
		if (objs.Length > 1)
			Destroy (this.gameObject);
		DontDestroyOnLoad (this.gameObject);
}
}
