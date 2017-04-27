using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBuilder : MonoBehaviour {

	public GameObject[] parts;
	
	// Use this for initialization
	void Start () {
		bool[] stages = GameManager.instance.stagesComplete;

		for (int i = 0; i < parts.Length; i++) {
			if (stages [i]) {
				parts [i].SetActive (true);
			} else {
				parts [i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
