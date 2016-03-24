using UnityEngine;
using System.Collections;

public class ScriptController : MonoBehaviour {
///testing
/// <summary>
/// will move this to scenen manager once i get more orginized  testinh 
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
	///note to self: 
	/// add a scipt controller to control vamera script incase of bullet hell section - as in player section player os on side - bullet hell center  flag it with bool 
	// Update is called once per frame
	public void manageScripts () {
	//temp sul for testing - wastes things not good 
	if(currentScene.currentScene == 1){//maybe tmove this to level manager when it checks for scenes as it is called once per trigger - testing only 
	platfromController.enabled= false;//change this so it does not add but has it as a contant 1-2-3 ..etc ( better incase of replay or resetting - error wil happen otherwise 
	shipController.enabled = true;
	}
	else {

	platfromController.enabled= true;
	shipController.enabled = false;
	}

	}
}
