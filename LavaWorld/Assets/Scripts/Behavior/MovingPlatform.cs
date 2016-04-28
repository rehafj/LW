using UnityEngine;
using System.Collections;
/// <summary>
/// the new platform script - starts moving if player steps on it - returns to initial pos when stepped off - cuntinues moving if player jumps on it
///this has been updated //does not hold at top anymore - removed that feature  
/// </summary>
public class MovingPlatform : MonoBehaviour {

public Transform pointA;
public Transform pointB;
bool moving = false;
public bool hold=false;
public int platFormSpeed=1;
// note - if we want to move it when the player jumps on it just keep hold condition below else comment it out:) - and resets it to its  first pos!
	
	// Update is called once per frame
	void FixedUpdate () {

		if(hold){


			if(moving){

				transform.position=   Vector3.MoveTowards(transform.position, pointB.position, platFormSpeed*Time.deltaTime);

				}
			else {	
				transform.position=   Vector3.MoveTowards(transform.position, pointA.position, platFormSpeed*Time.deltaTime);

					}

			if(transform.position.x <= pointA.transform.position.x){
					moving = true;
					}

		}//end of hold 
	}


	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player"){
	        hold = true;
	        moving = true;

    }}


	void OnTriggerEnter2D(Collider2D other) {
    
		if (other.gameObject.tag == "DestinationPoint"){
			moving = false;}

		}
//	void OnTriggerExit2D(Collider2D other)
//    {
//		hold = false;
//		transform.position = pointA.transform.position;
//    }



   ////// wanted to use this - but issues -> would not work per frame - ask or google 
//	void OnCollisionStay2D(Collision2D coll) {
//
//	//void OnTriggerStay2D(Collider2D other){
//		
//			if(coll.gameObject.tag== "Player"){
//
////			transform.Translate(-Vector3.right * Time.deltaTime);
////			transform.Translate(-Vector3.right * Time.deltaTime, Space.World);
//
//			//transform.position=   Vector3.MoveTowards(transform.position, pointB.position, platFormSpeed*Time.deltaTime);
//}
//	} 



//	void OnCollisionExit2D(Collision2D coll) {
//        if (coll.gameObject.tag == "Player")
//			moving = false;
//
//   		transform.position = pointA.transform.position;
//	}
}
