using UnityEngine;
using System.Collections;
/// <summary>
/// this script manages falling platforms 
/// there are many ways we can do this for now its done bt setting it as a collider/trigger an dplayong with kinemtic values 
///tell me if you have nay questions :D 
/// </summary>
public class FallingPlatform : MonoBehaviour {

	public bool steppedOn = false;//not used for nor just to check in inspector - 
	public float fallTimer = 1f;
	Rigidbody2D rgd;
	Vector3 currentPos;
	BoxCollider2D colr;
	Animator anim;

	void Awake(){
	rgd = GetComponent<Rigidbody2D>();
	currentPos = gameObject.transform.position;
		//Debug.Log(currentPos);
	colr = GetComponent<BoxCollider2D>();
	anim = GetComponent<Animator>();
	}
	
	// Update is called once per fram
	/// <summary>
	/// OF we want to male the player stand on platform we can add things where oncollider2dexit set it off - many ways to o this discuss with team 
	/// </summary>
	public void Falling(){
		anim.SetBool("timepass", true);

			rgd.isKinematic= false;
			colr.isTrigger= true;
		anim.Play("FallingPlat");
		//colr.enabled = false;

	}

	void OnCollisionEnter2D( Collision2D other ){
		if(other.gameObject.tag=="Player"){
        steppedOn = true;
		Invoke ("Falling" , fallTimer);
		}}
		 

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag =="death" ||other.gameObject.tag == "Ground" ){
		//Debug.Log("entred trigger");
		//	colr.enabled = false;
			rgd.isKinematic= true;
		

		Invoke("recreate",1);

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
