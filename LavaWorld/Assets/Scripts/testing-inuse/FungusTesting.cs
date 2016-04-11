using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;
public class FungusTesting : Flowchart {
//public Flowchart myflowchart;
public int currentScene;
public PlayerController plr;
	// Use this for initialization

	void Awake(){
	//Time.timeScale=0;
	plr = FindObjectOfType<PlayerController>();
	currentScene = SceneManager.GetActiveScene().buildIndex;
		startMessgesBasedOnScene( currentScene);

	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D( Collider2D coll){

	if(coll.gameObject.tag=="Player"){
				Debug.Log("Collided");
			SendFungusMessage("FUN");
			//plr.enabled =false;

}

}

public void StartBulletHelllDailog(){

		SendFungusMessage("BH");
	//	plr.enabled =false;


}
//	void OnLevelWasLoaded(){
//		currentScene = SceneManager.GetActiveScene().buildIndex;
//		if( currentScene==2){
//			Debug.Log("bullethell level");
//			//Time.timeScale=0;
//			//Time.timeScale=Time.deltaTime;
//
//	}
	

	void startMessgesBasedOnScene( int currentScene){

		if( currentScene ==2){

			SendFungusMessage("BH");
			//Time.timeScale=1;


			}
	}
	}



