using UnityEngine;
using System.Collections;

public class Batbehavior : MonoBehaviour {
bool movingRight = true;
//public GameObject player;
public float maxXpos = 9.58F;
public float minXpos = -9.5f;
public int speed = 2;


public float height = 10f;
public float width = 5f; 

Animator anim;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
//anim.applyRootMotion = true;
						//works but clunky - refactor 
	if(movingRight){
		//transform.Translate(-Vector3.right * 2 * Time.deltaTime);
		transform.position+= Vector3.right * speed *Time.deltaTime;
			Debug.Log("movingRight"+movingRight);
	if(transform.position.x <= maxXpos){
				Debug.Log("player pos is greater than max X set up");
			 movingRight =false;
				//transform.Translate(-Vector3.up * 0.5f * Time.deltaTime);
			}		


		//transform.position.y=  Mathf.Sin(1*Time.deltaTime);
	}
	else if(!movingRight){
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			if( transform.position.x >= minXpos){
		 movingRight = true;
			}	
		}	//transform.Translate(Vector3.up * 0.5f * Time.deltaTime);

}




}
/////										testing purposes 
//				if(movingRight){	
//					transform.Translate(-Vector3.right * speed * Time.deltaTime);}
//
//			else{
//					transform.Translate(Vector3.right * speed * Time.deltaTime);
//			} 
//			float objectrightE = transform.position.x + (0.5f* width);
//			float objectlEFTtE = transform.position.x - (0.5f* width);
//
//				if(objectlEFTtE < minXpos || objectrightE >maxXpos){
//
//					movingRight = !movingRight;
//				}
//			}