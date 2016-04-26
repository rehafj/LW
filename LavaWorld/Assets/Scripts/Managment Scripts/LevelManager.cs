using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// this script iwll be used to triverse across levels - so far  just created one method for the menu selection 
/// we will use this to move from level to level soon j
/// this script should presist and not have duplicate copies so it cpuld manage the level we are in 
/// </summary>
//TODO fix this script 
public class LevelManager : MonoBehaviour {

////current level
public static LevelManager InstanceOfLeve;
int currentScene;
PlayerStatus playerInstance;
public	int sceneCounter;
public int myPlayerHealth; 
public int myPlayerLives;
public int nextLevel;
public bool isHardMode = false;
	//public FungusTesting narration;
void Awake(){

		Time.timeScale =1;
		if(InstanceOfLeve!=null){//it exsits - destory it dont create another o=instacnae //do bnot dupilcate game managers 
		GameObject.Destroy(gameObject);
		//Debug.Log("DESTROOYED  INSTANCE");
		}

	else {//instance == nill 
		GameObject.DontDestroyOnLoad(gameObject);//do not destoyr teh current gameobject ( i..e scene instance) 
				InstanceOfLeve = this;
	}


}



public void SetInitialThings(){
	if( isHardMode ==false){
		LavaEffects.multip = 1;
		PlayerPrefs.SetInt("PlayerLives", myPlayerLives);
		PlayerPrefs.SetInt("PlayerHealth", myPlayerHealth);
		PlayerPrefs.SetInt("SPBullets", 0);
		}

	else if(isHardMode){
		LavaEffects.multip = 2;
		PlayerPrefs.SetInt("PlayerLives", 1 );
		PlayerPrefs.SetInt("PlayerHealth", myPlayerHealth);
		PlayerPrefs.SetInt("SPBullets", 0);
}
		
		

}

public void MoveToNextLevel(){
	
			playerInstance = FindObjectOfType<PlayerStatus>();

	if(playerInstance != null){

				PlayerPrefs.SetInt("PlayerLives",playerInstance.lives);
				PlayerPrefs.SetInt("PlayerHealth", playerInstance.health);
				PlayerPrefs.SetInt("SPBullets", PlayerStatus.SpecialBullets);

	}
	else {
	 Debug.LogError("no player was found");
	}

			nextLevel=sceneCounter+1;
		Debug.Log("loading next scene "+ nextLevel);

			SceneManager.LoadScene(nextLevel);
		}



		
public void  GameOver(){
		SceneManager.LoadScene(5);

			}


public void RestartGame(){
		sceneCounter=0;

		SceneManager.LoadScene(0);



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