using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enables the player and door keys to step through portals 
 * 
 * Basic structure adapted from unitytutorials.com youtube channel portal tutorial:
 * https://www.youtube.com/watch?v=sK9Qf8ElFHo
 * */

public class StepThroughPortal : MonoBehaviour {

    public GameObject otherPortal;

    void OnTriggerEnter(Collider other)
    {
        
        // if a player or door key comes into contact with the portal send it to the other portal and retain velocity
        if (other.tag == "Player" || other.tag == "DoorKey")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            // this float retains the velocity of the object so that it can leave the other portal at the speed that it entered the first
            float currVelMag = rb.velocity.magnitude;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = otherPortal.transform.forward *1f*currVelMag;
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward*transform.localScale.x;          
        }
    }
}
