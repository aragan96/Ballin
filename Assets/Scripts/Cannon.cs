﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour {

    public bool playerOnCannon;
    public GameObject player;
    GameObject sliderObject;
    Slider powerBar;

	// Use this for initialization
	void Start () {
        sliderObject = GameObject.Find("PowerBar");
        powerBar = sliderObject.GetComponent<Slider>();
        sliderObject.GetComponent<CanvasGroup>().alpha = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha6)&& playerOnCannon)
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            Vector3 fireDirection = camera.transform.forward;
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().AddForce(fireDirection * powerBar.value * 2000);
            player.GetComponent<Rigidbody>().useGravity = true;
            playerOnCannon = false;
            sliderObject.GetComponent<CanvasGroup>().alpha = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnCannon = true;
            Vector3 firePos = transform.GetChild(0).transform.position;
            other.transform.position = firePos;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Stop rotation too

            sliderObject.GetComponent<CanvasGroup>().alpha = 1f;

        // disable player controls
        // add an exit from cannon button gui
        }
    }
}
