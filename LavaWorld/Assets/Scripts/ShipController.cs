using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public Sprite Truckimg;
	public SpriteRenderer myImg;
	public int speed =3; 
	Rigidbody2D rgd;

	public float coolDownTimer=1;								// the lower this is th more bullets on screen at a time 
 	float DownTime =0;


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
	}

	void FireBullers(){

	GameObject temp = Pooler.currentPoller.ReturnPlayerBullets();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;//based on the bullets behavior - 
	temp.SetActive(true);

		DownTime = coolDownTimer;

	}

	void MoveTheTruck(){//add transtion for truk animations 

	int sideways = (int) Input.GetAxisRaw("Horizontal");//0 or 1 only 
		rgd.velocity= new Vector2(sideways * speed, rgd.velocity.y);


	}

	void OnEnable(){
		myImg.sprite = Truckimg;


	}
}
