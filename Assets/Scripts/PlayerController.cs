using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float speed;
    public Vector2 movementInput;
    public bool growInput;
    public bool shrinkInput;

    public float size = 1;
    public float minSize;
    public float maxSize;

    private Rigidbody rb;
    public Transform cam;
    public CameraController cc;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {   
        rb = GetComponentInChildren<Rigidbody>();
        cc = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        ApplyMovementInput();
        ApplySizeInput();
    }

    public void ApplyMovementInput()
    {
        Vector3 forward = new Vector3(cam.forward.x, 0.0f, cam.forward.z).normalized;
        Vector3 right = new Vector3(cam.right.x, 0.0f, cam.right.z).normalized;

        Vector3 movement = (movementInput.x * right) + (movementInput.y * forward);

        rb.AddForce(movement * speed);
    }

    public void ApplySizeInput()
    {
        // If both grow and shrink are disabled or both are enabled, do nothing.
        if (!growInput && !shrinkInput)
        {
            return;
        }

        if(growInput && (size < maxSize))
        {
            size = Mathf.Min(size + 0.05f, maxSize);
        }

        if(shrinkInput && (size > minSize))
        {
            size = Mathf.Max(size - 0.05f, minSize);
        }

        cc.scale = size;
        transform.localScale = new Vector3(size, size, size);
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("Bounce")) {
			rb.velocity = Vector3.up * 20;
		}
    }
}
