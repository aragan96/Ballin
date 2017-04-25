using System.Collections;
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
            player.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            player.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(fireDirection * powerBar.value * 2000);
            player.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            playerOnCannon = false;
            sliderObject.GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RightAngleCam>().enabled = true;
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
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RightAngleCam>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().enabled = true;
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = transform.GetChild(1).transform.position;
            sliderObject.GetComponent<CanvasGroup>().alpha = 1f;
            
        // add an exit from cannon button gui
        }
    }
}
