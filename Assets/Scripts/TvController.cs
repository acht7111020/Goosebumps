﻿using UnityEngine;
using System.Collections;

public class TvController : MonoBehaviour {
 
    private bool open = false;
    private Animator animation;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        animation = GetComponent<Animator>();
//        GetComponent<AIInformation>().Floor = 1;
	}
	
	// Update is called once per frame
	void Update () {
        animation.SetBool("on", open);
	}

    public void TrunOnTV(){
        open = true;
        audioSource.Play();
        Invoke("TrunOffTV", 5.0f);
    }

    void TrunOffTV() {
        open = false;
        audioSource.Stop();
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && UserControl.UseItem)
        {

			if (GameObject.Find ("SceneManager").GetComponent<MySceneManager> ().GameSceneIsGame ()) {
				GameObject[] monsters = GameObject.FindGameObjectsWithTag ("Monster");
				foreach (GameObject monster in monsters) {
					monster.GetComponent<BasicProperties> ().NewAttraction (gameObject);
				}
			}
            TrunOnTV();
        }
    }
}
