using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;
public class NarrativeFungusController : Flowchart {

public PlayerController playerPlatformer;
public ShipController truck;

int currentLevel;
//void awake -> find the player by type - player controller 

	// Update is called once per frame
	void Awake(){

	truck = FindObjectOfType<ShipController>();
	playerPlatformer = FindObjectOfType<PlayerController>();

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
    truck.enabled = true;
    	// player controller 
    	//enable th eplayer controller after time 
    }



}
