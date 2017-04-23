using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public bool unlocked;
    public string levelName;
    public GameObject portal;
    public int stage;

    void Start()
    {
        unlocked = GameManager.instance.stageUnlocked[stage];
        portal.SetActive(unlocked);
    }

    void OnTriggerEnter(Collider other)
    {
        if(unlocked && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
            GameManager.instance.currentStage = stage;
        }   
    }

    void Unlock()
    {
        unlocked = true;
        portal.SetActive(true);
    }
}
