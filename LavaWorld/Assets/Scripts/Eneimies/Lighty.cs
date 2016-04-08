using UnityEngine;
using System.Collections;
/// <summary>
/// specfic script for lighty's behavior 
/// </summary>


/// <summary>
/// note the lighty script works when the layer enters the trigger - if u hit anywhwere it recives dmg basically - 
///we will fix this to activating adn deactiviating this game object as we enter the scene -> this is just to illistrate a pint :D  
/// </summary>

public class Lighty : LavaEffects {//or we attach the scri[t and not have it inherit :P 

Vector3 currentPos;//will be used later
Animator anim;
bool isAlive;
public GameObject fireArea;
int num = 1;
public  Transform[] locations= new Transform[3];
//can have it internal via code - what do you prefer and call it cia object's name //find //this is where to spawn the fire 

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();


	}





	void OnBecameVisible() {
        enabled = true;
		InvokeRepeating("insFire2",3f,9f);

    }


	void OnBecameInvisible() {
		CancelInvoke("insFire2");
        enabled = false;
    }



	public void insFire2(){

		StartCoroutine(insFire());
		}

	

	IEnumerator  insFire(){
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

