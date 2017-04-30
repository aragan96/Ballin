using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
	public float jump=10;
    public float speed;
	public Vector3 latestCheckpoint;

	public GameObject SecondCanvas;
    public Vector2 movementInput;
    public bool growInput;
    public bool shrinkInput;

    public float size = 1;
    public float minSize;
    public float maxSize;

    public GameObject body;
    private Rigidbody rb;
    public Transform cam;

    PortalGun portalGun;

	public float gravity;
    
    [System.NonSerialized]
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
		latestCheckpoint = body.transform.position;
		Physics.gravity = new Vector3 (0, -gravity, 0);
        portalGun = GameObject.FindGameObjectWithTag("PortalGun").GetComponent<PortalGun>();
        Cursor.visible = false;
    }

    void Update()
    {
        if(GameManager.instance.paused)
        {
            return;
        }
        //if (Input.GetKeyDown ("space") && GetComponent<Rigidbody> ().transform.position.y <= 0.6250001f) {
        //Jump ();
        //}

        ApplyMovementInput ();
		ApplySizeInput ();
		Jump (jump);
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
           if (transform.GetChild(2).GetComponent<ThrowPortal>().portalGunAttached)
            {
                portalGun.size = Mathf.Min(portalGun.size + 0.025f, maxSize);
            }
        }

        if(shrinkInput && (size > minSize))
        {
            size = Mathf.Max(size - 0.05f, minSize);
            if (transform.GetChild(2).GetComponent<ThrowPortal>().portalGunAttached)
            {
                portalGun.size = Mathf.Max(portalGun.size - 0.025f, minSize);
            }
        }

        cc.scale = size;
        body.transform.localScale = new Vector3(size, size, size);
        portalGun.gameObject.transform.localScale = new Vector3(portalGun.size, portalGun.size, portalGun.size);
    }

	// Used for launching platforms
	public void Bounce(float power){
		rb.velocity = Vector3.up * power;
	}

	//when hitting an obstacle (fire) 
	/*void OnTriggerEnter(Collider other){
		if (other.tag == "Fire") {
			other.GetComponentInParent<PlayerController> ().GoToCheckpoint();
		}
	}*/
	//To jump when hitting space 
	public void Jump(float jump){
		if (Input.GetKeyDown(KeyCode.Space)){
			rb.velocity = Vector3.up * jump;
		}
	}

	// Used for saving checkpoints
	public void SaveCheckpoint(Vector3 pos){
		latestCheckpoint = pos;
		StartCoroutine (CheckpointMessage ());
	}

	public void GoToCheckpoint(){
		body.SetActive (false);
		StartCoroutine (RespawnAtCheckpoint());
	}
		

	IEnumerator RespawnAtCheckpoint(){
		yield return new WaitForSeconds (2f);
		body.SetActive (true);
		size = 1;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = new Vector3(0f,0f,0f);

		body.transform.position = latestCheckpoint + Vector3.up;
		//body.transform.localScale = new Vector3 (1, 1, 1);
	}

	IEnumerator CheckpointMessage(){
		SecondCanvas.SetActive (true);
		yield return new WaitForSeconds (2.5f);
		SecondCanvas.SetActive (false);
	}
}
