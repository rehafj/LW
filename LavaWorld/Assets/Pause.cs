﻿using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
bool ispauses = false;
bool showGui = false;
public GUITexture mytext;	// Use this for initialization
	GUIStyle style = new GUIStyle();
	void Start () {
		mytext=	gameObject.GetComponent<GUITexture>();
		style.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
	//if(Input.GetKeyDown("p")){
		if(Input.GetButtonDown("Pause")){
		ispauses = !ispauses;
		if( ispauses == true){
		Time.timeScale = 0;
			ispauses = true;
			showGui = true;
		}
		if( ispauses == false){
		Time.timeScale = 1;
			ispauses = false;
			showGui = false;

		}

	


	}


	}


			void OnGUI() {
		if(ispauses){
			//if (GUI.Button(new Rect(0, 0, Screen.width, Screen), "Pause"));
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "paused");
            }
        
    }
}
