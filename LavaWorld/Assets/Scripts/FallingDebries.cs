using UnityEngine;
using System.Collections;

public class FallingDebries : MonoBehaviour {

Transform mytrans;
public GameObject debries;
public int x =1;
	// Use this for initialization
	void Start () {
	mytrans = GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D plr){
		if(plr.gameObject.tag=="Player"){
	Debug.Log("collided and falling debries start");

			InvokeRepeating("InsFallingObjects",0.1f,0.5f);
			//Instantiate(debries, mytrans.position, Quaternion.identity);
			//x--;
			//Invoke ("addmore",0.5f);
			//Debug.Log(x);
		
	}
	}

	void InsFallingObjects(){
	//x++;

		Instantiate(debries, mytrans.position, Quaternion.identity);

	}



	void OnTriggerExit2D(Collider2D plr){
		if(plr.gameObject.tag=="Player"){

		CancelInvoke("InsFallingObjects");
		}
	}
}
