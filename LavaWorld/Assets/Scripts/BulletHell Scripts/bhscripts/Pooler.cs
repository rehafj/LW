using UnityEngine;
using System.Collections;
/// <summary>
/// this creates an array of bullets that are static - used for spaning bulets from player and enemies - does not grow / not a litst 
///size is assigned for now ( inorder to not have 2 many bullets on screen at a time) 
/// </summary>
public class Pooler : MonoBehaviour {

	public static Pooler currentPoller;
	public GameObject EnemyBullet; 
	public GameObject  playerBullet;
	public int Size=15;


	public GameObject [] EnemyBullets;
	public GameObject [] playerBullets;
		
	void Awake(){
		currentPoller = this;

		}


	void Start () {//


		CreateEnemyBullets();

		playerBullets = new GameObject[Size];

		for( int i = 0; i< Size; i++){
			GameObject temp = Instantiate(playerBullet);//create an instance of an pbject 
			temp.SetActive(false);
			playerBullets[i] = temp;//add it to the array 
	}



	}
	

	public  GameObject ReturnEnemyBullets(){
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






	public  void CreateEnemyBullets(){
		EnemyBullets = new GameObject[Size];
		for( int i = 0; i< Size; i++){
			GameObject temp = Instantiate(EnemyBullet);//create an instance of an pbject 
			temp.SetActive(false);
			EnemyBullets[i] = temp;//add it to the array 
	}}







	}


	/// <summary>
		/// this is done wrong - ill get back to it later - triverses it wrong - 
		//i'll change this into a list later 
		// or create them in an arrayy or list of lists - or dicitonaty with a key - ill get o yhis later 
		/// </summary>
		/// <returns>The random enmey.</returns>


//	public GameObject returnRandomEnmey(){
//		for( int i = 0 ; i< enemiesTypes.Length; i++){
//	//	Debug.Log(i+ "is the index of I");
//			for(int j = 0 ; j<enemiesTypes.Length ; j++){
////				Debug.Log(j+ "is the index of J");
//
//				if(!enemiesTypes[i].activeInHierarchy)//if its not active in herarcy 
//			//return the pooled object to return it 
//					return enemiesTypes[i];
//	}
//	}
////	Debug.Log("no enemy - null ");
//	return null;
//		}


