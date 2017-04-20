using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Vector3 playerPos;
    Vector3 direction;
    GameObject player;
    Rigidbody rigbod;
    public float speed;

    void Start()
    {
        rigbod = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null) { 
        var direction = Vector3.zero;
        direction = player.transform.position - transform.position;
        direction.Normalize();
        rigbod.velocity = direction * speed;
    }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if((transform.localScale.x * transform.localScale.y * transform.localScale.z) > (player.transform.localScale.x * player.transform.localScale.y * player.transform.localScale.z))
            {
                player.gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}