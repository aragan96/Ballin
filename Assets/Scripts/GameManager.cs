using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //MODIFIED GameManager script from Unity's GameManager tutorial

    // instance for Singleton pattern
    public static GameManager instance = null;

    public bool pauseInput;
    public bool paused = false;

    public string startLevel;

    // Number of collectables
    public int numCollectables = 3;

    // ID of current level (-1 if there is no collectable)
    public int currentStage;

    // Collectables collected
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

		stagesComplete = new bool[numCollectables];

		for (int i = 0; i < numCollectables; i++) {
			stagesComplete [i] = false;
		}
    }

	// Use this for initialization
	void Start () {

        
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            currentStage = -1;
            Cursor.visible = true;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        // ESC is pause except in main menu
		if (currentStage >= 0 && pauseInput) {
            if(paused)
            {
                Unpause();
            } else
            {
                Pause();
            }
		}
	}

    public void BeginGame()
    {
        Cursor.visible = false;
        currentStage = 0;
        SceneManager.LoadScene(startLevel);
    }

    public void Pause()
	{
        paused = true;

        // Show pause menu and cursor
        pauseMenu.SetActive(true);
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    public void Unpause()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        //Hide cursor unless returning to main menu
        if(currentStage >= 0)
        {
            Cursor.visible = false;
        }
    }

	public void Restart(){
        PlayerController.instance.latestCheckpoint = new Vector3(0, 0.5f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Unpause();
	}

	public void MainMenu(){
        PlayerController.instance.latestCheckpoint = new Vector3(0, 0.5f, 0);
        SceneManager.LoadScene ("Main Menu");
        currentStage = -1;
        Unpause();
    }

	public void Quit()
	{
		Application.Quit();
	}
}
