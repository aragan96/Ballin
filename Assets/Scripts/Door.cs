using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public string levelName;
    public GameObject portal;
	public Light myLight;
    public int stage;

    void Start()
    {

		if (GameManager.instance.stagesComplete [stage]) {
			myLight.color = Color.green;
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
            GameManager.instance.currentStage = stage;
        }   
    }
}
