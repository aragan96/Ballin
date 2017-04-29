﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour {

    public GameObject otherPortal;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "DoorKey")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            float currVelMag = rb.velocity.magnitude;
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward*transform.localScale.x;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = otherPortal.transform.forward * 1f * currVelMag;
        }
    }
}
