using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public bool locked;
    public string levelName;
    public GameObject portal;

    void Start()
    {
        locked = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!locked && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }   
    }
}
