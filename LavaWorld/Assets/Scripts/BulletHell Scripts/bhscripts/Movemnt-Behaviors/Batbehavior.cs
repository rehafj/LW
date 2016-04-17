using UnityEngine;
using System.Collections;

public class Batbehavior : MonoBehaviour {
bool movingRight = true;
//public GameObject player;
 float maxXpos = 10f;
 float minXpos = -9.5f;
public int speed = 2;


//public float height = 5f;
//public float width = 5f; 


Animator anim;
	// Use this for initialization
	void Awake () {
		setBounds();
	}
	
	// Update is called once per frame
	void FixedUpdate () {



//anim.applyRootMotion = true;
						//works but clunky - refactor 
	if(movingRight){

		transform.position+= Vector3.right * speed *Time.deltaTime;

		if(transform.position.x >= maxXpos){
			 movingRight =false;}		

	}

	else if(!movingRight){
			transform.Translate(Vector3.left * speed * Time.deltaTime);

			if( transform.position.x <= minXpos){
				 movingRight = true;
				}	
		}	//transform.Translate(Vector3.up * 0.5f * Time.deltaTime);

}



	public void setBounds(){
		Vector3 screenBounds = new Vector3( Screen.width, Screen.height, 0);
		Vector3 bounds = Camera.main.ScreenToWorldPoint(screenBounds);
		//beter to get this by getting the lplayer sixe and then deviding stuff 
		minXpos = -bounds.x/2f;
		maxXpos = bounds.x/2f;

	}


}
