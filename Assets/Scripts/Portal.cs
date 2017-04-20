using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit.");
        if(other.CompareTag("Player"))
        {
            Debug.Log("HIT");
        }
    }

}
