using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Allows a platform to move
 * */

public class MovingPlatform : MonoBehaviour {


    public float MoveDistance;
    public float MoveSpeed;

    Vector3 startPos;
    Vector3 endPos;

    void Start()
    {
        startPos = new Vector3(transform.position.x - MoveDistance, transform.position.y, transform.position.z);
        endPos = new Vector3(transform.position.x + MoveDistance, transform.position.y, transform.position.z);
    }

    // Update is called once per frame--moves the platform left and right
    void Update()
    {
        transform.position = Vector3.Lerp(startPos, endPos, (Mathf.Sin(MoveSpeed * Time.time) + 1.0f) / 2.0f);
    }
}
