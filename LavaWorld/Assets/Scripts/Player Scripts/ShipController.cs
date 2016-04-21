﻿using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public Sprite Truckimg;
	public SpriteRenderer myImg;
	public int speed =3; 
	Rigidbody2D rgd;

	public float coolDownTimer=1;								// the lower this is th more bullets on screen at a time 
 	float DownTime =0;

public	bool cantGetHurt = false;
public float invincbLastFor = 1f;
float invincbTimer;

public Transform Gun1, Gun2; 
public GameObject SPBullets;
	// Use this for initialization
	void Start () {
	rgd = GetComponent<Rigidbody2D>();
	myImg = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame


	void FixedUpdate () {

	MoveTheTruck();
		if(DownTime>0)
			DownTime -= Time.deltaTime;


		else if( Input.GetButtonDown("shoot")){

			FireBullers();
		}

		if(invincbTimer>=0){ invincbTimer-=Time.deltaTime;}

		if( invincbTimer <= 0) {
			cantGetHurt = false;
		}
	}

	void FireBullers(){

	if( PlayerStatus.SpecialBullets>0){

	///change this to pooler quick fix for testing 
			Instantiate( SPBullets, Gun1.transform.position, Gun1.transform.rotation);
			Instantiate( SPBullets, Gun2.transform.position, Gun2.transform.rotation);
			PlayerStatus.DencreamentBullets();

	} else 
	{
			

	GameObject temp = Pooler.currentPoller.ReturnPlayerBullets();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;//based on the bullets behavior - 
	temp.SetActive(true);

		DownTime = coolDownTimer;

	}
	}
	void MoveTheTruck(){//add transtion for truk animations 

	int sideways = (int) Input.GetAxisRaw("Horizontal");//0 or 1 only 
		rgd.velocity= new Vector2(sideways * speed, rgd.velocity.y);


	}

	void OnEnable(){
		myImg.sprite = Truckimg;


	}


	public void CheckInvinibility(){
		invincbTimer = invincbLastFor;
		cantGetHurt = true;
	}
}
