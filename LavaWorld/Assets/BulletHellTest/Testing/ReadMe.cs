using UnityEngine;
using System.Collections;

public class ReadMe : TestingPollingGeneric {
/// <summary>
/// crememner to create a pooler that would inherit from the genral pooler and change he object to spawn 
///- check with team - ask about types of bullets ...etc 
/// </summary>
	// Use this for initialization
//	void Start () {
//
//InvokeRepeating("LetLooseTheBullets",1,1);
//	}
/// <summary>
/// add somthing to reset the postion of enemies to top based on spanner and pull them from a lust - change it from an array - create list of lists in one manager might be easyer 
/// </summary>

	void Start () {//
		myPooledgameObjects = new GameObject[Size];
		for( int i = 0; i< Size; i++){
			GameObject temp = Instantiate(myPooledgameObject);//create an instance of an pbject 
			temp.SetActive(false);
			myPooledgameObjects[i] = temp;//add it to the array 
	}

	}
	
	// Update is called once per frame


	public void LetLooseTheBullets(){//cz my naming gets crazy oh well :P 
	GameObject temp = TestingPollingGeneric.currentPoller.ReturnPooledObect();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;
	temp.SetActive(true);
	}

}
