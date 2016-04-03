using UnityEngine;
using System.Collections;

public class FallingDebries : MonoBehaviour {
/// <summary>
/// temporary - wil use another method instead of instantistying will pull it to reduce load 
/// </summary>
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


	 
	//void OnTriggerEnter2D(Collider2D plr){
	//	if(plr.gameObject.tag=="Player"){
	void OnBecameVisible() {
	//Debug.Log("collided and falling debries start");

			InvokeRepeating("InsFallingObjects",0.1f,0.5f);
			//Instantiate(debries, mytrans.position, Quaternion.identity);
			//x--;
			//Invoke ("addmore",0.5f);
			//Debug.Log(x);
		
	}


	void InsFallingObjects(){
	//x++;

	GameObject temp = Pooler.currentPoller.ReturnEnemyBullets();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;//based on the bullets behavior - 
	temp.SetActive(true);


	//	Instantiate(debries, mytrans.position, Quaternion.identity);

	}



	//void OnTriggerExit2D(Collider2D plr){
	//	if(plr.gameObject.tag=="Player"){
	void OnBecameInvisible() {


		CancelInvoke("InsFallingObjects");
		}
	}
