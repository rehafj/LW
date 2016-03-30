using UnityEngine;
using System.Collections;

public class Pooler : MonoBehaviour {

	public static Pooler currentPoller;
	public GameObject EnemyBullet; 
	public GameObject  playerBullet;
	public int Size=50;

	public GameObject[] enemiesTypes = new GameObject[3];

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


	///intilize enemy bullet list and creat them - set them to deactive 
		EnemyBullets = new GameObject[Size];
		for( int i = 0; i< Size; i++){
			GameObject temp = Instantiate(EnemyBullet);//create an instance of an pbject 
			temp.SetActive(false);
			EnemyBullets[i] = temp;//add it to the array 
	}
		///intilize Player bullet list and creat them - set them to deactive 

		playerBullets = new GameObject[20];
		for( int i = 0; i< 20; i++){
			GameObject temp = Instantiate(playerBullet);//create an instance of an pbject 
			temp.SetActive(false);
			playerBullets[i] = temp;//add it to the array 
	}


		for( int i = 0; i< enemiesTypes.Length; i++){
			for( int j = 0; j< 4; j++ ){
			GameObject temp = Instantiate(enemiesTypes[i]);//create an instance of an pbject 
			temp.SetActive(false);
				enemiesTypes[i] = temp;//add it to the array 
	}}//spawned 6 enemies 



	}
	

	public GameObject ReturnEnemyBullets(){
		for( int i = 0 ; i< EnemyBullets.Length; i++){

			if(!EnemyBullets[i].activeInHierarchy)//if its not active in herarcy 
			//return the pooled object to return it 
				return EnemyBullets[i];}
				///else return null
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




	public GameObject returnRandomEnmey(){
		for( int i = 0 ; i< enemiesTypes.Length; i++){
			for(int j = 0 ; j< 4 ; j++){
				if(!enemiesTypes[j].activeInHierarchy)//if its not active in herarcy 
			//return the pooled object to return it 
					return enemiesTypes[j];
	}
	}
	Debug.Log("no enemy - null ");
	return null;
		}





}
