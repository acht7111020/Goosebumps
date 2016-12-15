﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using System.Collections.Generic;

public class MySceneManager : MonoBehaviour {

    public string currentSceneName;

    List<GameObject> gearList = new List<GameObject>();
    List<GameObject> sceneList = new List<GameObject>();
    GameObject player;

	public  string GAMESCENE1 = "GameScene-chap1";
	public  string GAMESCENE2 = "GameScene-chap2";
	public  string PREVIEW1 = "PreviewScene-chap1";
	public  string PREVIEW2 = "PreviewScene-chap2";

    public static MySceneManager ins;
    void Awake() {
        if (ins == null)
        {
            ins = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else if (ins != this)
            Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        //gameController = GameObject.Find("GameHandle");
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    // For any gear that player put in the scene
    public void addToGearList(GameObject g) {
        GameObject.DontDestroyOnLoad(g);
        gearList.Add(g);
    }

    public void removeFromGearList(GameObject g)
    {
        gearList.Remove(g);
    }

    public void addToSceneList(GameObject g)
    {
        GameObject.DontDestroyOnLoad(g);
        sceneList.Add(g);
    }

    public void removeAllFromSceceList( )
    {
        foreach (GameObject g in sceneList)
        {
            Destroy(g);
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name + " " + scene.buildIndex );
        Debug.Log(mode);

		currentSceneName = scene.name;

		if (currentSceneName == GAMESCENE1 || currentSceneName == GAMESCENE2) {  // if not preview, mean game start!
            foreach (GameObject g in gearList)
            {
                Destroy(g.GetComponent<PickUpItem>());
            }
            player.GetComponent<Character>().setFloor();
        }
		else if (currentSceneName == PREVIEW1 || currentSceneName == PREVIEW2) { // reload preview scene
            player = GameObject.Find("Player");
            
            foreach(GameObject g in gearList){
                Destroy(g);
            }
            gearList.Clear();
        }
    }

	public bool GameSceneIsPreview(){
		if (currentSceneName == PREVIEW1 || currentSceneName == PREVIEW2) { // reload preview scene
			return true;
		}else 
			return false;
	}

	public bool GameSceneIsGame(){
		if (currentSceneName == GAMESCENE1 || currentSceneName == GAMESCENE2) { // reload preview scene
			return true;
		}else 
			return false;
	}
     
}
