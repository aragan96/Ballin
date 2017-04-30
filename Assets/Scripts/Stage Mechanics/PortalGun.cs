using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The script that is attached to the portal gun so that it follows the mouse point and also has a target
 * sighting so that the player can see where they are shooting
 * 
 * World to viewpoint script to enable targeting system adapted from Unity user "Sylos" on the following forum:
 * http://answers.unity3d.com/questions/799616/unity-46-beta-19-how-to-convert-from-world-space-t.html
 * */

public class PortalGun : MonoBehaviour
{
    // Gun positioning variables
    public bool gunOnTop = false;
    public GameObject playerBody;
    Vector3 offset;
    public float size;
    
    //Used for the targeting
    RectTransform target;
    RectTransform canvasRect;
    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        offset = new Vector3(0, playerBody.transform.localScale.x / 2, 0);
        canvasRect = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>();
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<RectTransform>();
        target.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // if the gun is on top point it at the raycast hit along with the target point
        if (gunOnTop)
        {
            target.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
            
            // get the middle of the screen and draw raycast from top of the gun to that point
            int x = Screen.width / 2;
            int y = (Screen.height / 2) + (Screen.height / 6);
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //make the gun face the hit point and position the target on the point on the screen where the hit is
                transform.LookAt(hit.point);
                Vector2 viewportPosition = mainCamera.GetComponent<Camera>().WorldToViewportPoint(hit.point);
                Vector2 hitPointScreenPosition = new Vector2(((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)), ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
                target.anchoredPosition = hitPointScreenPosition;
            }

            //Reposition the portalgun on the player if the player shrank or grew
            offset = new Vector3(0, playerBody.transform.localScale.x / 2, 0);
            transform.position = playerBody.transform.position + offset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        //When the player collides with a gun attach it to the player
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ThrowPortal>().portalGunAttached = true;
            gunOnTop = true;
            Vector3 gunPos = other.transform.position + offset;
            transform.position = gunPos;
        }
    }
}
