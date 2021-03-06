﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    // Door which transports player to specified level

    public string levelName;
    public GameObject portal;
	public Light myLight;
    public int stage;

    void Start()
    {
        // Light above reflects the completion of stage within
		if (GameManager.instance.stagesComplete [stage]) {
			myLight.color = Color.green;
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
            PlayerController.instance.latestCheckpoint = new Vector3(0, 0.5f, 0);
            GameManager.instance.currentStage = stage;
        }   
    }
}
