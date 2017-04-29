using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //MODIFIED GameManager script from Unity's GameManager tutorial

    // instance for Singleton pattern
    public static GameManager instance = null;

    public bool paused = false;

    public string startLevel;

    public int numStages = 5;
    public int currentStage = 0;
	public bool[] stagesComplete;

	public GameObject pauseMenu;

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

		stagesComplete = new bool[numStages];

		for (int i = 0; i < numStages; i++) {
			stagesComplete [i] = false;
		}
    }

	// Use this for initialization
	void Start () {

        
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            currentStage = -1;
            Cursor.visible = true;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		if (currentStage >= 0 && Input.GetKeyDown (KeyCode.Escape)) {
			TogglePause ();
		}
	}

    public void BeginGame()
    {
        currentStage = 0;
        Cursor.visible = false;
        SceneManager.LoadScene(startLevel);
    }

    public void TogglePause()
	{
        paused = !paused;

		// Show pause menu
		pauseMenu.SetActive(paused);
        Cursor.visible = (paused) || (currentStage == -1);

        // Freeze the game
        if (paused)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }

	}

	public void Restart(){
        PlayerController.instance.latestCheckpoint = new Vector3(0, 0.5f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		TogglePause ();
	}

	public void MainMenu(){
        PlayerController.instance.latestCheckpoint = new Vector3(0, 0.5f, 0);
        SceneManager.LoadScene ("Main Menu");
        currentStage = -1;
        TogglePause();
    }

	public void Quit()
	{
		Application.Quit();
	}
}
