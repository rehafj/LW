using UnityEngine;
using System.Collections;

public class TestingPollingGeneric : MonoBehaviour {

	public static TestingPollingGeneric currentPoller;
	public GameObject myPooledgameObject; 
	public int Size=4;

	public GameObject []myPooledgameObjects;
	//List < GameObject> enemies;
	// Use this for initialization

	void Awake(){
		currentPoller = this;

		}
	void Start () {//
		myPooledgameObjects = new GameObject[Size];
		for( int i = 0; i< Size; i++){
			GameObject temp = Instantiate(myPooledgameObject);//create an instance of an pbject 
			temp.SetActive(false);
			myPooledgameObjects[i] = temp;//add it to the array 
	}

	}
	
	// Update is called once per frame

	public GameObject ReturnPooledObect(){
	//	for(int i = 0 ; i<enemies.Count;i++){
		for( int i = 0 ; i< myPooledgameObjects.Length; i++){

			if(!myPooledgameObjects[i].activeInHierarchy)//if its not active in herarcy 
			//return the pooled object to return it 
				return myPooledgameObjects[i];
//		{
//add condtion and checking statment so that it would grow Vs not ... 
//		}
	}

	//else give back null
	return null;
		}
}
