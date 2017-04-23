using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //MODIFIED GameManager script from Unity's GameManager tutorial

    // instance for Singleton pattern
    public static GameManager instance = null;

    public int numStages;
    public int currentStage = 0;
    public bool[] stageUnlocked;

	public GameObject pauseMenu;

	Vector3 checkPoint;

	GameObject playerBody;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        stageUnlocked = new bool[numStages + 1];

//        stageUnlocked[0] = true;
//        stageUnlocked[1] = true;
//
//        for (int i = 2; i < numStages; i++)
//            stageUnlocked[i] = true;
    }

	// Use this for initialization
	void Start () {
		playerBody = GameObject.Find ("Player/Body");
		checkPoint = playerBody.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

	public void Pause()
	{
		// Show pause menu
		pauseMenu.SetActive(true);

		// Freeze the game
		Time.timeScale = 0;

	}

	public void Unpause()
	{
		// Hide pause menu
		pauseMenu.SetActive(false);

		// Unfreeze the game
		Time.timeScale = 1;

		pauseMenu.SetActive (false);
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Unpause ();
	}

	public void MainMenu(){
		SceneManager.LoadScene ("Main Menu");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
