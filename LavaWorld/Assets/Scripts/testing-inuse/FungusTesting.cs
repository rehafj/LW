using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;
public class FungusTesting : Flowchart {
//public Flowchart myflowchart;
public int currentScene;
public PlayerController plr;
bool hasTalked = false;
	// Use this for initialization

	void Awake(){
	//Time.timeScale=0;
	plr = FindObjectOfType<PlayerController>();
	currentScene = SceneManager.GetActiveScene().buildIndex;
		//startMessgesBasedOnScene( currentScene);
		hasTalked = false;
	}


	void OnTriggerEnter2D( Collider2D coll){

	if(coll.gameObject.tag=="Player" && hasTalked == false){
			//	Debug.Log("Collided");
			//plr.enabled = false;
		Debug.Log("inside triger");
			SendFungusMessage("Test");
			plr.rgd.velocity = new Vector3(0,plr.rgd.velocity.y, 0f);

			plr.enabled = false;
			//plr.enabled =false;

}

}

public void ActivatePLayer(){

		plr.enabled = true;
		hasTalked = true;


}
//
//public void StartBulletHelllDailog(){
//
//		SendFungusMessage("BH");
//	//	plr.enabled =false;
//
//
//}
////	void OnLevelWasLoaded(){
////		currentScene = SceneManager.GetActiveScene().buildIndex;
////		if( currentScene==2){
////			Debug.Log("bullethell level");
////			//Time.timeScale=0;
////			//Time.timeScale=Time.deltaTime;
////
////	}
//	
//
//	void startMessgesBasedOnScene( int currentScene){
//
//		if( currentScene ==2){
//
//			SendFungusMessage("BH");
//			//Time.timeScale=1;
//
//
//			}
//	}
	}



