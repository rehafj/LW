using UnityEngine;
using System.Collections;

///this class will spawn things at the spawn's location 
public class Spawnner : MonoBehaviour {
//ti=his class will spawn objects at a random x range ( each time it spawns it will add 0-3 spaces based on code below - so check itout we can change it later :D 
public GameObject WhatToSpawn;
public int howManyToSpawn=1;
public bool passedTrigger = false;//change this to private and have a trigger aactivate it when collided with it //this bool will be set by a trigger a pla=yer passes through 

		BoxCollider2D mytigger ;
		GameObject triggerSpawns;//the thing that will set off the spawn action - it will be achild and we can move it later 
		Transform spawnLocation ;
		Vector3 currentPos;//to reset teh spawner to its iniital postion 
//to set te range at wh things will spawn on an x scale 
public int randomrange1=1, torane=2;

	// Use this for initialization
	void Start () {
	spawnLocation = GetComponent<Transform>();
	mytigger=GetComponent<BoxCollider2D>();
	PlaceTrigger();
	 currentPos = transform.position;
		//myLocations = GetComponents<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
	if(passedTrigger && howManyToSpawn>=0){
		chooseRandomX();
		Instantiate(WhatToSpawn, spawnLocation.position,Quaternion.identity);
				howManyToSpawn--;
		}	



	}

	void PlaceTrigger(){//or dispable thisa nd aplay with it manually -_-
		Vector2 temp = new Vector2(-0.62f,-11.55f);//3.66
		mytigger.offset= temp;//will place the vox 3 units below where it is  and 2 units to +x axsis 


	}

	void chooseRandomX(){

		float randomX = Random.Range(randomrange1,torane);
		Vector3 temp = new Vector3(randomX,0,0);
		spawnLocation.position += temp;
	

	}
	/// <summary>
	/// once the player passes this things will spawn 
	/// </summary>
	/// <param name="plr">player's collider.</param>
	void OnTriggerEnter2D(Collider2D plr){
	if(plr.gameObject.tag=="Player"){
		passedTrigger=true;
		mytigger.enabled=false;
		if(howManyToSpawn<=0){
				howManyToSpawn=3;
				}
		Invoke("resetPosOfSpawner",10);	//it will disable the box collider for 10 sec - will not spawn unless the player comes back here again 
	}

	}

	void resetPosOfSpawner (){
		spawnLocation.position = currentPos;
		mytigger.enabled=true;
	}

	}



