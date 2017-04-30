using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    // Handles all input and directs it to the relevant controller/manager scripts

    PlayerController playerController;
    CameraController camController;
    ThrowPortal portalControl;

    public Camera cam;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        camController = cam.GetComponent<CameraController>();
        portalControl = GetComponentInChildren<ThrowPortal>();
    }

    void Update()
    {
        float camHorizontal = Input.GetAxis("Mouse Y");
        float camVertical = Input.GetAxis("Mouse X");
        camController.camInput = new Vector2(camHorizontal, camVertical);

		playerController.growInput = Input.GetMouseButton(1);
		playerController.shrinkInput = Input.GetMouseButton(0);

        GameManager.instance.pauseInput = Input.GetKeyDown(KeyCode.Escape);

        if(portalControl.enabled)
        {
            portalControl.leftThrowInput = Input.GetKeyDown(KeyCode.Q);
            portalControl.rightThrowInput = Input.GetKeyDown(KeyCode.E);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        playerController.movementInput = new Vector2(moveHorizontal, moveVertical);
    }
}

