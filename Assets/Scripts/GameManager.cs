using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //MODIFIED GameManager script from Unity's GameManager tutorial

    // instance for Singleton pattern
    public static GameManager instance = null;

    public int numStages;
    public int currentStage = 0;
    public bool[] stageUnlocked;

//    public delegate void EventHandler(GameObject unit);

 //   public static event EventHandler tutorialComplete;

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

        stageUnlocked[0] = true;
        stageUnlocked[1] = true;

        for (int i = 2; i < numStages; i++)
            stageUnlocked[i] = true;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
