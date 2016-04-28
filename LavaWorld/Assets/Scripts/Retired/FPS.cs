using UnityEngine;
using System.Collections;

public class FPS : FallingPlatform {

int timerPassed=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public  override void  OnCollisionEnter2D( Collision2D other ){
		if(other.gameObject.tag=="Player"){
			steppedOn = true;
			timerPassed++;
			if( timerPassed <= 1 )
			steppedOn = false;
			Invoke ("Falling" , fallTimer);
		}}
}
