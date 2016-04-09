using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// this script iwll be used to triverse across levels - so far  just created one method for the menu selection 
/// we will use this to move from level to level soon 
/// this script should presist and not have duplicate copies so it cpuld manage the level we are in 
/// </summary>
//TODO fix this script 
public class LevelManager : MonoBehaviour {

////current level
public static LevelManager InstanceOfLeve;

PlayerStatus playerInstance;
public	int currentScene;
public int myPlayerHealth; 
public int myPlayerLives;
void Awake(){
		//playerInstance = FindObjectOfType<PlayerStatus>();

}
void Start(){


	if(InstanceOfLeve!=null){//it exsits - destory it dont create another o=instacnae //do bnot dupilcate game managers 
		GameObject.Destroy(gameObject);
		}

	else {//instance == nill 
		GameObject.DontDestroyOnLoad(gameObject);//do not destoyr teh current gameobject ( i..e scene instance) 
				InstanceOfLeve = this;
		//GameObject.DontDestroyOnLoad(Player);
	}


		//if( Player!=null){


//if(playerInstance.Playerinstance !=null){//check this out or move it to player script 
	//	GameObject.Destroy(Player);
		//	Debug.Log("player instance!=null");
		//}

	// }

}
//void Update(){
//
////SceneManager.LoadScene(0);
//
//}



public void SetInitialThings(){
		currentScene++;
		PlayerPrefs.SetInt("PlayerLives", myPlayerLives);
		PlayerPrefs.SetInt("PlayerHealth", myPlayerHealth);

}

public void MoveToNextLevel(){
	//less than three levels // remmeber to change this depending on how we orginize the levels so far lelv 1 is 0 bh is 1 and lvl 2 is 2 - with menue this will change 
			//currentScene += number;
			currentScene++;


			playerInstance = FindObjectOfType<PlayerStatus>();//ask about this - if i move the scene manager it wont read it on awake unless i have 
			//un;ess i have other //would it be bad if i had one player.dfind ocated here ? 
		if(playerInstance != null){
				Debug.Log("Player lives is " + playerInstance.lives);
				PlayerPrefs.SetInt("PlayerLives",playerInstance.lives);
				PlayerPrefs.SetInt("PlayerHealth", playerInstance.health);
				Debug.Log("setting the thing to player prefs /n health moves is "+ PlayerPrefs.GetInt("PlayerHealth")+"and the lives is" + PlayerPrefs.GetInt("PlayerLives"));

	}
		else if (playerInstance == null){Debug.Log("player is null");}
		//	PlayerPrefs.SetInt("PlayerLives")
			//Debug.Log("Ceunner scene"+currentScene);
			//Debug.Log(" number sent over"+number);
				SceneManager.LoadScene(currentScene);
				//Debug.Log("inside method - increaed curent scene");
		}
		 


		
public void  GameOver(){
		SceneManager.LoadScene(4);

			}


public void RestartGame(){
		SceneManager.LoadScene(0);
		currentScene=0;



}
		//}

}//add something else to check win screen ot loose screen 
	

	

///make the player presistant and just add a method to reset values at the start of game over and then the player loads on evry scene for the fun of it 
///or add a check not to check for the player on level 0-4 (gameoever an dmenue ) or add the player for fun!
//	 Player = GameObject.FindGameObjectWithTag("Player");
//	 if(Player!=null){
//	 playerInstance = Player.GetComponent<PlayerStatus>();//going to check this inside payer class - 
//	 initialPostion = Player.GetComponent<Transform>();}

		//if(playerInstance.lives<=0){
		//	playerInstance.resetVlues();
		//	SceneManager.LoadScene(4);
		//	GameObject.Destroy(Player);
		//GameObject Player;
// Transform initialPostion;
 //ScriptController playerScript;