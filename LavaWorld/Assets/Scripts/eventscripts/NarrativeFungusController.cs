using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;
/// <summary>
/// handles fungus based on level load 
/// </summary>
public class NarrativeFungusController : Flowchart {

public PlayerController playerPlatformer;
public ShipController truck;
public Timer startTimer;
public 	BhSpawnEnimies spawner;

int currentLevel;
//void awake -> find the player by type - player controller 

	// Update is called once per frame
	void Awake(){

	truck = FindObjectOfType<ShipController>();
	playerPlatformer = FindObjectOfType<PlayerController>();
	startTimer = FindObjectOfType<Timer>();
	spawner = FindObjectOfType<BhSpawnEnimies>();
	if(spawner!=null){
			 	 spawner.enabled= false;

	}
	}

	void Update () {
	
	}



	public void OnLevelWasLoaded() {
	//what level you are in 
	//
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("current level is "+ currentLevel);

		if(playerPlatformer!=null){
		playerPlatformer.enabled = false;
		}

		if( truck!=null){
		truck.enabled = false;

		}

//		if(currentLevel ==1 ){
//		Debug.Log(" inside first if statmtnet ");
//		//disable player movment 
//			// disable 0-
//			SendFungusMessage("Test");}
//		else if (currentLevel ==2 )
//		{
//			SendFungusMessage("IntroTwo");
//
//		}
//		else if (currentLevel ==3 )
//		{
//			SendFungusMessage("IntroThree");
//
//		}
    }


    public void RecivingMsg(){
    Debug.Log("msg recived from flow chart");
	playerPlatformer.enabled = true;

    	// player controller 
    	//enable th eplayer controller after time 
    }

	public void RecivingMsg2(){
    Debug.Log("msg recived from flow chart");
    startTimer.narrativeIsOver= true;
	spawner.enabled= true;
    truck.enabled = true;
    	// player controller 
    	//enable th eplayer controller after time 
    }



}
