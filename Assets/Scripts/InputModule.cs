using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{

    PlayerController playerController;
    CameraController camController;

    RightAngleCam rotatingCameraController;

    public Camera cam;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        camController = cam.GetComponent<CameraController>();
        rotatingCameraController = cam.GetComponent<RightAngleCam>();
    }

    void Update()
    {
        float camHorizontal = Input.GetAxis("Mouse Y");
        float camVertical = Input.GetAxis("Mouse X");
        camController.camInput = new Vector2(camHorizontal, camVertical);

        rotatingCameraController.camRotate = Input.GetKey("space");

		playerController.growInput = Input.GetMouseButton(1);
		playerController.shrinkInput = Input.GetMouseButton(0);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        playerController.movementInput = new Vector2(moveHorizontal, moveVertical);
    }
}

