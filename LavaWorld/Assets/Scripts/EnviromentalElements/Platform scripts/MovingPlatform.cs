using UnityEngine;
using System.Collections;
/// <summary>
/// the new platform script - starts moving if player steps on it - returns to initial pos when stepped off 
/// </summary>
public class MovingPlatform : MonoBehaviour {

public Transform pointA;
public Transform pointB;
bool moving = false;
public bool holdAtTop=false;//if this is true the [;atfpr, will  not return to intial pont
public int platFormSpeed=1;
	// Use this for initialization
	void Start () {

//	pointA = gameObject.transform.GetChild(0);
//	pointB = gameObject.transform.GetChild(1);


	
	}
	
	// Update is called once per frame
	void Update () {

		if(moving){
			transform.position=   Vector3.MoveTowards(transform.position, pointB.position, platFormSpeed*Time.deltaTime);

		}
		else if(holdAtTop==false){	
				transform.position=   Vector3.MoveTowards(transform.position, pointA.position, platFormSpeed*Time.deltaTime);}

		//transform.Translate(-Vector3.right * Time.deltaTime);
			//transform.Translate(Vector3.right * Time.deltaTime, Space.World);

	}




	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player"){

        moving = true;

    }}


	void OnTriggerEnter2D(Collider2D other) {
    
		if (other.gameObject.tag == "DestinationPoint"){
			moving = false;
			//print("triggerwise moving is "+moving);

		}}



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
