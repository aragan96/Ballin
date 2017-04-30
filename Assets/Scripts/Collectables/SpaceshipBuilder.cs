using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBuilder : MonoBehaviour {

	public GameObject[] parts;
    public GameObject completeShip;
	
	// Use this for initialization
	void Start () {

        bool winCondition = true;

        // Checks if the player has collected all pieces of the jet
        // and sets winCondition to true if so.
		for (int i = 0; i < parts.Length; i++) {
			if (GameManager.instance.stagesComplete[i]) {
                winCondition = winCondition && true;
				parts [i].SetActive (true);
			} else {
                winCondition = false;
                parts [i].SetActive (false);
			}
        }
       

        // If the player has completed the jet, the complete jet will appear
        // in the lobby.
        if(winCondition)
        {
            for(int i = 0; i < parts.Length; i++)
            {
                parts[i].SetActive(false);
            }
            transform.localScale = new Vector3(7.5f, 0.1f, 7.5f);
            transform.position = new Vector3(0, 0, 0);
            completeShip.SetActive(true);
        } else
        {
            completeShip.SetActive(false);
        }
	}
}
