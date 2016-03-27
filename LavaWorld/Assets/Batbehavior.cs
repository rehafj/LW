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
	anim = GetComponent<Animator>();
	anim.Play("Enem1Entry");
//	//ulternate method instead of hard values 
//	//get camera's bonds //0 of x azsis 
//	Vector3 LeftSide= Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
//	//1 on x axsis
//	maxXpos = LeftSide.x;
//	Vector3 rightSide= Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
//	minXpos = rightSide.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//anim.applyRootMotion = true;
						//works but clunky - refactor 
	if(movingRight){
		transform.Translate(-Vector3.right * 2 * Time.deltaTime);
	if( transform.position.x > maxXpos){
			 movingRight = !movingRight;
				//transform.Translate(-Vector3.up * 0.5f * Time.deltaTime);
			}		


		//transform.position.y=  Mathf.Sin(1*Time.deltaTime);
	}else if(!movingRight){
			transform.Translate(Vector3.right * 2 * Time.deltaTime);
			if( transform.position.x <= minXpos){
		 movingRight = !movingRight;
			}	
		}	transform.Translate(Vector3.up * 0.5f * Time.deltaTime);

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