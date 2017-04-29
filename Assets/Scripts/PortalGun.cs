using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{

    public bool gunOnTop = false;
    public GameObject playerBody;
    Vector3 offset;
    public float size;

    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        offset = new Vector3(0, playerBody.transform.localScale.x / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gunOnTop)
        {
            int x = Screen.width / 2;
            int y = (Screen.height / 2) + (Screen.height / 6);
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point);
            }
            offset = new Vector3(0, playerBody.transform.localScale.x / 2, 0);
            transform.position = playerBody.transform.position + offset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ThrowPortal>().portalGunAttached = true;
            gunOnTop = true;
            Vector3 gunPos = other.transform.position + offset;
            transform.position = gunPos;
        }
    }
}
