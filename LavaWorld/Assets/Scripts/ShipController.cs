using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	Sprite img;
	public int speed =3; 
	Rigidbody2D rgd;
	// Use this for initialization
	void Start () {
	rgd = GetComponent<Rigidbody2D>();
	rgd.isKinematic = true;
	 // remmeber to uncheck this in player conrtoler script 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	MoveTheTruck();

		if( Input.GetButtonDown("shoot")){
			FireBullers();
		}
	}

	void FireBullers(){

	GameObject temp = Pooler.currentPoller.ReturnPlayerBullets();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;//based on the bullets behavior - 
	temp.SetActive(true);


	}

	void MoveTheTruck(){//add transtion for truk animations 

	int sideways = (int) Input.GetAxisRaw("Horizontal");//0 or 1 only 
		rgd.velocity= new Vector2(sideways * speed, rgd.velocity.y);


	}
}
