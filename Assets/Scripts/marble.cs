using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marble : MonoBehaviour {
	GameObject marbles;
	Rigidbody rigbod;
	Vector3 direction;
	public float speed;
	// Use this for initialization
	void Start () {
		rigbod = GetComponent<Rigidbody>();
		marbles = GameObject.FindGameObjectWithTag("marble");
	}
	
	// Update is called once per frame
	void Update () {
		direction = marbles.transform.position - transform.position;
		direction.Normalize();
		rigbod.velocity = direction * speed;
	}

void OnCollisionEnter(Collision other)
{
	if (other.gameObject.tag == "marble")
	{
			Destroy(gameObject);
		}
	}
}


