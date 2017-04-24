using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour {

    PlayerController playerController;
    CameraController camController;

    public Camera cam;

	void Start () {
        playerController = GetComponent<PlayerController>();
        camController = cam.GetComponent<CameraController>();
	}
	
	void Update()
    {
        float camHorizontal = Input.GetAxis("Mouse Y");
        float camVertical = Input.GetAxis("Mouse X");
        camController.camInput = new Vector2(camHorizontal, camVertical);

        playerController.growInput = Input.GetKey(KeyCode.Alpha1);
        playerController.shrinkInput = Input.GetKey(KeyCode.Alpha2);
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        playerController.movementInput = new Vector2(moveHorizontal, moveVertical);
    }
}
