using UnityEngine;
using System.Collections;
//drops items 40% chance depending on random value 
public class DropItems : MonoBehaviour {
int x;
LavaEffects status;

public GameObject collectable;

	// Use this for initialization
	void Start () {
	status = GetComponent<LavaEffects>();

	}
	
	// Update is called once per frame
	public void DropCollectable () {

	if(status.wasDestroyed ==true){//not needed anymore 

	 x = Random.Range(1,10);

	 Debug.Log(x +" IS calue of x");

	if(x>6){
			Instantiate(collectable, gameObject.transform.position, gameObject.transform.rotation);
			Debug.Log("item Was instanitaed");

	}

	}
	}}

