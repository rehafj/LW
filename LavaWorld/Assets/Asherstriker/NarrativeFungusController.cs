using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;
public class NarrativeFungusController : Flowchart {

int currentLevel;
//void awake -> find the player by type - player controller 

	// Update is called once per frame
	void Update () {
	
	}



	void OnLevelWasLoaded() {
	//what level you are in 
	//
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("current level is "+ currentLevel);


		if(currentLevel ==1 ){
		Debug.Log(" inside first if statmtnet ");
		//disable player movment 
			// disable 0-
			SendFungusMessage("BH");}
		else if (currentLevel ==2 )
		{
			SendFungusMessage("IntroTwo");

		}
		else if (currentLevel ==3 )
		{
			SendFungusMessage("IntroThree");

		}
    }


    public void RecivingMsg(){
    Debug.Log("msg recived from flow chart");
    	// player controller 
    	//enable th eplayer controller after time 
    }


}
