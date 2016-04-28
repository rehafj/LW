using UnityEngine;
using System.Collections;
/// <summary>
/// this script manages falling platforms // o rthings that fall when hit - simple script 
///they currently reset and recrate when they hit the death collides or ground / by playing with triggers and colliders... 
/// there are many ways we can do this for now its done bt setting it as a collider/trigger an dplayong with kinemtic values 
/// </summary>
public class FallingPlatform : MonoBehaviour {

	public bool steppedOn = false;//not used for nor just to check in inspector - 
	public float fallTimer = 1f;
	Rigidbody2D rgd;
	Vector3 currentPos;
	BoxCollider2D colr;
	Animator anim;
	public float recrationTime =1f;

	void Awake(){
		rgd = GetComponent<Rigidbody2D>();
		currentPos = gameObject.transform.position;
			//Debug.Log(currentPos);
		colr = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
	}
	

	public virtual void Falling(){
		anim.SetBool("timepass", true);
		rgd.isKinematic= false;
		colr.isTrigger= true;
		anim.Play("FallingPlat");

	}

	public virtual void  OnCollisionEnter2D( Collision2D other ){
		if(other.gameObject.tag=="Player"){
      	    steppedOn = true;
			Invoke ("Falling" , fallTimer);
		}}
		 

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag =="InsDeath" ||other.gameObject.tag == "Ground" ){
		Debug.Log("entred trigger changing things ");
		//	colr.enabled = false;
			rgd.isKinematic= true;
		

			Invoke("recreate",recrationTime);

			//Destroy(gameObject,2);
			//make a method to move it upwards 
		}
    }


	void recreate(){
		anim.SetBool("timepass", false);
		gameObject.transform.position =currentPos;
		//colr.enabled = true;
		steppedOn = false;
		colr.isTrigger= false;




	}
	


}
