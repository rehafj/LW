using UnityEngine;
using System.Collections;

public class FallingDebries : MonoBehaviour {
/// <summary>
/// temporary - wil use another method instead of instantistying will pull it to reduce load 
/// </summary>
public GameObject debries;
public ObjectPooler lavaDroplets;
public int x =1;
	// Use this for initialization


	void OnBecameVisible() {

			InvokeRepeating("InsFallingObjects",0.1f,x);

		
	}


	void InsFallingObjects(){

		GameObject temp = lavaDroplets.RetrivePooledObject();//gives acses to the ppoo for the ginafwm 

		if(temp==null)
			return ;

		temp.transform.position = gameObject.transform.position;
		temp.transform.rotation = gameObject.transform.rotation;//based on the bullets behavior - 
		temp.SetActive(true);



	}


	void OnBecameInvisible() {


		CancelInvoke("InsFallingObjects");
		}
	}
