using UnityEngine;
using System.Collections;

/// <summary>
/// a very simple script 
/// inhirits from lava effects 
///moves fire on a pattern ( instant) 1-2-3-1-2-3 planned that way
/// </summary>


/// <summary>
/// note the lighty script works when the layer enters the trigger - if u hit anywhwere it recives dmg basically - 
///we will fix this to activating adn deactiviating this game object as we enter the scene -> this is just to illistrate a pint :D  
/// </summary>

public class Lighty : LavaEffects {//or we attach the scri[t and not have it inherit :P 
 int currentScene; 
Vector3 currentPos;//will be used later
Animator anim;
bool isAlive;
public GameObject fireArea;
int num = 1;
public  Transform[] locations= new Transform[3];
	//public MoveToNextLevel activePortal;
	//public GameObject portal;
//can have it internal via code - what do you prefer and call it cia object's name //find //this is where to spawn the fire 

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		//activePortal = FindObjectOfType<MoveToNextLevel>();
	//	activePortal.gameObject.SetActive(false);


	}


	//this is a v old script that has not been updated - logic is flawed - will fix in future drafts 

	//add somehting to reset game object if player is out of scene ( now) but that resets health /// <summary>
	///  have to check what to do tiwht that 
	///

	public override void  ResetEnemValues(){ //for the future need to override this becuase enemyies are based on random and if this is ued in bh part = issues respawns same place but we need an ovverride to reset values only and not pos 
		wasDestroyed = false;
		//gameObject.SetActive(true);
		//activePortal.gameObject.SetActive(true);
		Debug.Log("overrided method was called");
		HitsToDestroy = initialHitsToDestory;
		//portal.SetActive(true);
		//activePortal.enabled = true;
}




	/// </summary>
	void OnBecameVisible() {
		InvokeRepeating("insFire2",3f,9f);

    }


	void OnBecameInvisible() {
		CancelInvoke("insFire2");
	 HitsToDestroy = initialHitsToDestory;
    }



	public void insFire2(){

		StartCoroutine(insFire());
		}

	

	IEnumerator  insFire(){
	//spawns it at l=places 1-2-3 
		for(int i = 0; i<= locations.Length-1; i++){
			//Debug.Log("spawned at"+i);
			if(num>=0)
			Instantiate(fireArea, locations[i].position, Quaternion.identity);//loop instatinates once when used on start 
			num--;
			yield return new WaitForSeconds(3f);
			num++;
			}
		yield return new WaitForSeconds(3f);

	}




	}

