﻿using UnityEngine;
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

		



		/// <summary>
		/// note this is temporary untill we activate deactivate things based on camera object 
		/// </summary>
		/// <param name="plr">Plr.</param>

	void OnTriggerEnter2D(Collider2D plr){

	if(plr.gameObject.tag=="Player"){
		//Debug.Log("player inlighty area number of times");

			//StartCoroutine(insFire());
			InvokeRepeating("insFire2",3f,9f);
		//	Debug.Log("back to collider");
			//Instantiate(debries, mytrans.position, Quaternion.identity);
			//x--;
			//Invoke ("addmore",0.5f);
			//Debug.Log(x);
		
	}
	}

	void OnTriggerExit2D(Collider2D plr){
		if(plr.gameObject.tag=="Player"){

			CancelInvoke("insFire2");
			//StopCoroutine(insFire());
		}
	}
//
	public void insFire2(){

//		for(int i = 0; i<= locations.Length-1; i++){
//			Debug.Log("spawned at"+i);
//			Instantiate(fireArea, locations[i].position, Quaternion.identity);

		StartCoroutine(insFire());
		}
		//Instantiate(fireArea, SpwanPoint.position, Quaternion.identity);

	

	IEnumerator  insFire(){
	//for(int i =0 ; i<
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

