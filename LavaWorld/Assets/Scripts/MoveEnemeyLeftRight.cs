using UnityEngine;
using System.Collections;

public class MoveEnemeyLeftRight : MonoBehaviour {


public Transform pointA;
public Transform pointB;
public bool movingRight = false;
public int enemSpeed=1;
	public float WaitTime =5;
	// Use this for initialization
	void Start () {

//	pointA = gameObject.transform.GetChild(0);
//	pointB = gameObject.transform.GetChild(1);


	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(movingRight){
			transform.position=   Vector3.MoveTowards(transform.position, pointB.position, enemSpeed*Time.deltaTime);
		
		}
		else if(!movingRight){	
			transform.position=   Vector3.MoveTowards(transform.position, pointA.position, enemSpeed*Time.deltaTime);}
		
		//transform.Translate(-Vector3.right * Time.deltaTime);
			//transform.Translate(Vector3.right * Time.deltaTime, Space.World);

	}


	void OnBecameVisible() {
        enabled = true;
    }


	void OnBecameInvisible() {
        enabled = false;
    }














//	void OnTriggerEnter2D(Collider2D other) {
//    
//		if (other.gameObject.tag == "Right"){
//		Debug.Log("collided with right");
//			moving = true;
//			//print("triggerwise moving is "+moving);
//
//		}		if (other.gameObject.tag == "Left"){
//			moving = false;
//			//print("triggerwise moving is "+moving);	}
//		}
//	
//}



}

