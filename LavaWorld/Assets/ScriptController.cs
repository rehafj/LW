using UnityEngine;
using System.Collections;

public class ScriptController : MonoBehaviour {
/// <summary>
/// will move this to scenen manager once i get more orginized 
/// </summary>
	PlayerController platfromController;
	ShipController shipController;
	public LevelManager currentScene;
	GameObject x;
	// Use this for initialization
	void Awake () {
	 platfromController = GetComponent<PlayerController>();
	 shipController = GetComponent<ShipController>();
	currentScene = FindObjectOfType<LevelManager>();//sets it to scene manager 
	platfromController.enabled= true;
	shipController.enabled = false;

	}
	
	// Update is called once per frame
	public void manageScripts () {
	//temp sul for testing - wastes things not good 
	if(currentScene.currentScene == 1){//maybe tmove this to level manager when it checks for scenes as it is called once per trigger - testing only 
	platfromController.enabled= false;
	shipController.enabled = true;
	}
	else {

	platfromController.enabled= true;
	shipController.enabled = false;
	}

	}
}
