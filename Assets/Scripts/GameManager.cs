using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //MODIFIED GameManager script from Unity's GameManager tutorial

    // instance for Singleton pattern
    public static GameManager instance = null;

    public int numStages = 5;
    public int currentStage = 0;
	public bool[] stagesComplete;

	public GameObject pauseMenu;

	GameObject playerBody;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

		stagesComplete = new bool[numStages + 1];

		for (int i = 0; i < numStages; i++) {
			stagesComplete [i] = false;
		}
    }

	// Use this for initialization
	void Start () {
		playerBody = GameObject.Find ("Player/Body");
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
