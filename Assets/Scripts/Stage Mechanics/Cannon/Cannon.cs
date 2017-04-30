using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Fires the player in the direction of the camera from the cannon when the player is attached
 * */

public class Cannon : MonoBehaviour {

    //Get the camera and power bar slider
    public bool playerOnCannon;
    public GameObject player;
    GameObject sliderObject;
    Slider powerBar;
    GameObject mainCamera;

	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");
        sliderObject = GameObject.Find("PowerBar");
        powerBar = sliderObject.GetComponent<Slider>();
        sliderObject.GetComponent<CanvasGroup>().alpha = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerOnCannon)
        { 
            
            //Make a ray from the camera to the center of the screen to get direction of fire
            int x = Screen.width / 2;
            int y = (Screen.height / 2);
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.GetChild(1).transform.LookAt(hit.point);
                player.transform.GetChild(2).transform.position = transform.GetChild(1).transform.GetChild(2).transform.position;
            }

            //Fire the player along the calculated ray
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
                Vector3 fireDirection = camera.transform.forward;
                player.transform.GetChild(2).GetComponent<Rigidbody>().isKinematic = false;
                player.transform.GetChild(2).GetComponent<Rigidbody>().AddForce(fireDirection * powerBar.value * 2000);
                player.transform.GetChild(2).GetComponent<Rigidbody>().useGravity = true;
                playerOnCannon = false;
                sliderObject.GetComponent<CanvasGroup>().alpha = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnCannon = true;
            Vector3 firePos = transform.GetChild(1).transform.GetChild(2).transform.position;
            other.transform.position = firePos;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            sliderObject.GetComponent<CanvasGroup>().alpha = 1f;
        }
    }
}
