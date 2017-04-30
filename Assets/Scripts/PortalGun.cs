using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    //
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
        if (gunOnTop)
        {
            target.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
            int x = Screen.width / 2;
            int y = (Screen.height / 2) + (Screen.height / 6);
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point);
                Vector2 viewportPosition = mainCamera.GetComponent<Camera>().WorldToViewportPoint(hit.point);
                Vector2 hitPointScreenPosition = new Vector2(((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)), ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
                target.anchoredPosition = hitPointScreenPosition;
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
