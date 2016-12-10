﻿using UnityEngine;
using System.Collections;

public class PhoneController : MonoBehaviour {
    
    private AudioSource audioSource;
    private Animator animation;
    private bool enable = true;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Player" && Input.GetKeyDown("z"))
        {
            GameObject[] phones = GameObject.FindGameObjectsWithTag("Phone");
            foreach (GameObject phone in phones)
            {
                if (!Vector3.Equals(phone.transform.position, gameObject.transform.position)) { 
                    PhoneController p = phone.GetComponent<PhoneController>();
                    audioSource.Stop();
                    p.PlaySoundEffect();
                }
            }
        }
    }

    void PlaySoundEffect(){
        if (enable)
        {
            Debug.Log("Phone ring: " + gameObject.name);
            audioSource.Play();
            enable = false;
            animation.SetBool("ring", true);
            GameObject.Find("monster").GetComponent<MonsterControl>().NewAttraction(gameObject);
            Invoke("ReEnable", 5.0f);
        } 
    }

    void ReEnable(){
        enable = true;
        audioSource.Stop();
        animation.SetBool("ring", false);
    }
}
