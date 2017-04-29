using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour {

    public GameObject leftPortal;
    public GameObject rightPortal;
    public bool portalGunAttached;
    GameObject portalGun;

	// Use this for initialization
	void Start () {
        portalGun = GameObject.FindWithTag("PortalGun");
	}
	
	// Update is called once per frame
	void Update () {
        if (portalGunAttached)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                throwPortal(leftPortal);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                throwPortal(rightPortal);
            }
        }
	}

    void throwPortal(GameObject portal){
        RaycastHit hit;
        Vector3 fwd = portalGun.transform.GetChild(1).transform.forward;
        if (Physics.Raycast(portalGun.transform.GetChild(1).transform.position, fwd * 50, out hit) && hit.collider != null)
        {
            if (hit.collider.CompareTag("PortalWall"))
            {
                Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
                portal.transform.position = hit.point;
                portal.transform.rotation = hitObjectRotation;
                //portal.transform.parent = hit.transform;
            }
        }
    }
}
