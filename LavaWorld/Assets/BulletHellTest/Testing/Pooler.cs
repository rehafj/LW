using UnityEngine;
using System.Collections;

public class Pooler : MonoBehaviour {

	public static Pooler currentPoller;
	public GameObject EnemyBullet; 
	public GameObject  playerBullet;
	public GameObject[] enemiesTypes;
	public int Size=4;

	public GameObject [] EnemyBullets;
	public GameObject [] playerBullets;
	//List < GameObject> enemies;
	// Use this for initialization
	/// This is just a temparary fix - it stores all objects with a set size hence an array 
	///to make this more robost - change it to lists mght be better( dynamic ) if we will need to make our bullet list grow at runtime 
	///but if it has a fixed size - shoudl be ok
	/// for the future -
	///
	///for now this class defined seprate objects to be pulled - note to self: rememebr to play with it - maybe have a class inherit it and set the type of object to be pulled from there
	///instead of creating it from this script and just calling it/setting deactive from other scripts
	/// for the future ->
	///				
	void Awake(){
		currentPoller = this;

		}
	void Start () {//
		EnemyBullets = new GameObject[Size];
		for( int i = 0; i< Size; i++){
			GameObject temp = Instantiate(EnemyBullet);//create an instance of an pbject 
			temp.SetActive(false);
			EnemyBullets[i] = temp;//add it to the array 
	}

		playerBullets = new GameObject[20];
		for( int i = 0; i< 20; i++){
			GameObject temp = Instantiate(playerBullet);//create an instance of an pbject 
			temp.SetActive(false);
			playerBullets[i] = temp;//add it to the array 
	}

	}
	

	public GameObject ReturnEnemyBullets(){
		for( int i = 0 ; i< EnemyBullets.Length; i++){

			if(!EnemyBullets[i].activeInHierarchy)//if its not active in herarcy 
			//return the pooled object to return it 
				return EnemyBullets[i];}
	return null;
		}


	public GameObject ReturnPlayerBullets(){
		for( int i = 0 ; i< playerBullets.Length; i++){

			if(!playerBullets[i].activeInHierarchy)//if its not active in herarcy 
			//return the pooled object to return it 
				return playerBullets[i];

	}

	return null;
		}


}
