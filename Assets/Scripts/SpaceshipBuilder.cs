using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBuilder : MonoBehaviour {

	public GameObject[] parts;
    public GameObject completeShip;
	
	// Use this for initialization
	void Start () {

        bool winCondition = true;
        
		for (int i = 0; i < parts.Length; i++) {
			if (GameManager.instance.stagesComplete[i]) {
                winCondition = winCondition && true;
				parts [i].SetActive (true);
			} else {
                winCondition = false;
                parts [i].SetActive (false);
			}
        }
       
        if(winCondition)
        {
            for(int i = 0; i < parts.Length; i++)
            {
                parts[i].SetActive(false);
            }
            transform.position = new Vector3(0, 0, 0);
            completeShip.SetActive(true);
        } else
        {
            completeShip.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
