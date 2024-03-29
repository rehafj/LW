﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// triverses music through scenes By getting the active build on scene load 
///plays spec music on menue/ bullet heall/ platform 
///hard coded value - if we had more might make it odd/even music loops. within a range 
/// </summary>
public class MusicManagerT : MonoBehaviour {
	public Scene myscene;
	public int sceneNumber;
	public AudioSource myMusic;
	public static MusicManagerT musicInstance;
	public AudioClip[] myAudioSources = new AudioClip[3];
	public AudioClip currentClip;
	public LevelManager _indexOfScene;
	// Use this for initialization
	void Awake(){
//	Debug.Log("called");

		myMusic = GetComponent<AudioSource>();
		currentClip = GetComponent<AudioSource>().clip;
				//sceneNumber = _indexOfScene.currentScene;
		myMusic.Play();

		
		if(musicInstance !=null){
				GameObject.Destroy(this.gameObject);
		}
		else {
				GameObject.DontDestroyOnLoad(gameObject);
				musicInstance = this;}

		_indexOfScene = FindObjectOfType<LevelManager>();
//	Debug.Log("level manager foudn ~");
		if(_indexOfScene!=null){	
		//Debug.Log("level manager foudn ~");


			//sceneNumber = _indexOfScene.nextLevel;
			sceneNumber = SceneManager.GetActiveScene().buildIndex;

		}
		else
		Debug.Log("no level manager");



	}


	void OnLevelWasLoaded(){
		sceneNumber = SceneManager.GetActiveScene().buildIndex;
//		Debug.Log(sceneNumber);
			myMusic.Stop();
		if(sceneNumber>0 && sceneNumber<4){
//			Debug.Log("in scenes of play - putting player music");
			if(sceneNumber==2){
		//		Debug.Log("in bullet hell");
				currentClip = myAudioSources[2];
			}
			//just for git testing 
			else {
			//	Debug.Log("scene is platformer");
				currentClip = myAudioSources[0];
				}
				myMusic.clip = currentClip;
				myMusic.Play();			

		}
		else{
		//	Debug.Log("menu or gameover scene");

			currentClip = myAudioSources[1];
			myMusic.clip = currentClip;
			myMusic.Play();	}	
	}
}
