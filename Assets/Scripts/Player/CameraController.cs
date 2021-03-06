﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour { 

    //EXTENDED 3rd person Camera Controller script from lab

    public Transform player;

    [System.NonSerialized]
    public Vector2 camInput;

    public RaycastHit obstacleHit;
    public LayerMask playerMask;

    float distance;
    public float scale;

    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    
    public float minVerticalAngle = -80.0f;
    public float maxVerticalAngle = 80.0f;

    public float verticalSpeed = 150.0f;
    public float horizontalSpeed = 300.0f;

    private float angleX;
    private float angleY;

    void Start()
    {
        distance = maxDistance;
        angleX = -20;
        angleY = 0;
    }

    void Update()
    {
        ApplyCameraInput();
    }

    void ApplyCameraInput()
    {
        angleX += camInput.x * Time.deltaTime * verticalSpeed;
        angleY += camInput.y * Time.deltaTime * verticalSpeed;

        angleX = Mathf.Clamp(angleX, minVerticalAngle, maxVerticalAngle);
        angleY %= 360;

        Quaternion xRotation = Quaternion.AngleAxis(angleX, new Vector3(1, 0, 0));
        Quaternion yRotation = Quaternion.AngleAxis(angleY, new Vector3(0, 1, 0));
        Vector3 offset = new Vector3(0, 0, 1);
        offset = xRotation * offset;
        offset = yRotation * offset;

        RaycastHit hit;

        // If there is an object between the player and the camera
        if (Physics.Raycast(player.position, transform.position - player.position, out hit, maxDistance * scale, playerMask))
        {
            // Place the camera in front of the obstacle but also outside of the player
            distance = Mathf.Clamp(hit.distance, minDistance * scale, maxDistance * scale);
        }
        else
        {
            // Reset the camera to its normal distance
            distance = maxDistance * scale;
        }

        offset *= distance;
        transform.position = player.position + offset;
        transform.rotation = Quaternion.LookRotation(player.position - transform.position, new Vector3(0, 1, 0));
    }
}
