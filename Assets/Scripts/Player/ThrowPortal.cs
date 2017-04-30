using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Throws a portal from the gun onto a portal wall
 * 
 * Basic structure adapted from unitytutorials.com youtube channel portal tutorial:
 * https://www.youtube.com/watch?v=sK9Qf8ElFHo 
 * */

public class ThrowPortal : MonoBehaviour {

    //the two portals and the gun
    public GameObject leftPortal;
    public GameObject rightPortal;
    public bool portalGunAttached;
    GameObject portalGun;

    public bool rightThrowInput = false;
    public bool leftThrowInput = false;

	void Start () {
        portalGun = GameObject.FindWithTag("PortalGun");
	}
	
	void Update () {

        //if the gun is attached throw a portal
        if (portalGunAttached)
        {
            if (leftThrowInput)
            {
                throwPortal(leftPortal);
            }
            if (rightThrowInput)
            {
                throwPortal(rightPortal);
            }
        }
	}

    void throwPortal(GameObject portal){

        //resets the transform in the case the portal was just placed on a moving platform
        portal.transform.parent = null;

        //raycast from the gun to the wall
        RaycastHit hit;
        Vector3 fwd = portalGun.transform.GetChild(1).transform.forward;
        if (Physics.Raycast(portalGun.transform.GetChild(1).transform.position, fwd * 50, out hit) && hit.collider != null)
        {
            if (hit.collider.CompareTag("PortalWall"))
            {

                //rotate the portal so that it is the correct orientation on the wall
                Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
                portal.transform.position = hit.point;
                portal.transform.rotation = hitObjectRotation;

                //move the portal with the moving platform
                if (hit.transform.gameObject.GetComponent<MovingPlatform>() != null)
                {
                    portal.transform.parent = hit.transform;
                }
            }
        }
    }
}
