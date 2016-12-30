﻿using UnityEngine;
using System.Collections;

public class MagicTreeController : MonoBehaviour {

    public int MAXSTONE = 5;
    public GameObject TreeBridge;
    int count = 0;
	// Use this for initialization
	void Start () {
        TreeBridge.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LightTheStone() {
        count++;
        if (count >= MAXSTONE )
        {
            Camera.main.GetComponent<CameraController>().CameraMovement();
            TreeBridge.SetActive(true);
            count = 0;
            if (GameObject.Find("KingMonster2") ) 
				GameObject.Find("KingMonster2").GetComponent<PotionDamage>().setStartToDestroyed();
        }
    }
}
