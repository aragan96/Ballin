using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetePortal : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
}
