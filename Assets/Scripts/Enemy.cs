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
        var direction = Vector3.zero;
        Debug.Log(player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();
        rigbod.velocity = direction * speed;
    }
}