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
static LevelManager InstanceOfLeve;
 GameObject Player;
 Transform initialPostion;
 ScriptController playerScript;
 PlayerStatus playerInstance;
public	int currentScene=0;

void Start(){
///make the player presistant and just add a method to reset values at the start of game over and then the player loads on evry scene for the fun of it 
///or add a check not to check for the player on level 0-4 (gameoever an dmenue ) or add the player for fun!
	 Player = GameObject.FindGameObjectWithTag("Player");
//	 Debug.Log(Player.name);
	 playerInstance = Player.GetComponent<PlayerStatus>();//going to check this inside payer class - 
	 initialPostion = Player.GetComponent<Transform>();

	if(InstanceOfLeve!=null){//it exsits - destory it dont create another o=instacnae //do bnot dupilcate game managers 
		GameObject.Destroy(gameObject);
		}
		//if( Player!=null){


//if(playerInstance.Playerinstance !=null){//check this out or move it to player script 
	//	GameObject.Destroy(Player);
		//	Debug.Log("player instance!=null");
		//}

	// }

	else {//instance == nill 
		GameObject.DontDestroyOnLoad(gameObject);//do not destoyr teh current gameobject ( i..e scene instance) 
				InstanceOfLeve = this;
		//GameObject.DontDestroyOnLoad(Player);
	}

}
//void Update(){
//
////SceneManager.LoadScene(0);
//
//}

public void LoadlevelfromMenue( int Level_number){

		SceneManager.LoadScene(Level_number);

}

public void MoveToNextLevel(int number){
print("moved to next level");
	if(number<3){//less than three levels // remmeber to change this depending on how we orginize the levels so far lelv 1 is 0 bh is 1 and lvl 2 is 2 - with menue this will change 
			currentScene += number;
				SceneManager.LoadScene(currentScene);

		}
		}
public void  GameOver(){
		print("moved to gameo ver");

		if(playerInstance.lives<=0){
			playerInstance.resetVlues();
			SceneManager.LoadScene(4);
			GameObject.Destroy(Player);

			}
		//}

}//add something else to check win screen ot loose screen 
	

	
}
