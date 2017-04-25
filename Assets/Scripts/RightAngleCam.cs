using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAngleCam : MonoBehaviour
{
    public Transform player;

    [System.NonSerialized]
    public Vector2 camInput;

    public bool camRotate;

    public float orbitDistance = 10f;
    public float orbitDegreesPerSec = -180.0f;
    public float maxDistance = 10f;
    Vector3 offset;

    public int upVector;

    void Start()
    {
        transform.position = player.position + (transform.position - player.position).normalized * orbitDistance;
        offset = transform.position - player.transform.position;
        upVector = 1;
    }

    void Update()
    {

        RaycastHit hit;

        // If there is an object between the player and the camera
        if (Physics.Raycast(player.position, transform.position - player.position, out hit))
        {
            // Place the camera in front of the obstacle but also outside of the player
            orbitDistance = Mathf.Clamp(hit.distance, player.localScale.x, maxDistance);
            offset = offset.normalized * orbitDistance;
        }
        else
        {
            // Reset the camera to its normal distance
            orbitDistance = maxDistance;
            offset = offset.normalized * orbitDistance;
        }

        if (camRotate)
        {
            Vector3 orbitVector = player.position + (transform.position - player.position).normalized * orbitDistance;
            transform.position = new Vector3(orbitVector.x, orbitVector.y * upVector, orbitVector.z);
            transform.RotateAround(player.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
          
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, new Vector3(0, upVector, 0));
            offset = transform.position - player.transform.position;
            offset.y = offset.y * upVector;
        }
        else
        {
            
            transform.position = new Vector3(player.transform.position.x + offset.x,player.transform.position.y + offset.y*upVector, player.transform.position.z + offset.z);
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, new Vector3(0, upVector, 0));
        }
    }
}




