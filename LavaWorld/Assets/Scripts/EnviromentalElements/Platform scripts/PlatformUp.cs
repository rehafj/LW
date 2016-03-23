using UnityEngine;
using System.Collections;
/// <summary>
/// this is an old platform script that moves between a min and a max point 
// it works but i also added another script that would cmove an object if stood upon - migth combine them into a single script of platform behaviors and have them based on checks and funcitnaliyy 
///this was  arandom test script ( done for the rough draft) 
/// </summary>
public class PlatformUp : MonoBehaviour {

		
		
		public bool max;
		
	// Use this for initialization

		void Update(){

	if(max == true){

			transform.Translate(Vector3.forward * Time.deltaTime);
			transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		}
	else if(max == false){
				transform.Translate(Vector3.forward * Time.deltaTime);
				transform.Translate(Vector3.down * Time.deltaTime, Space.World);
		}
	}
		
	
	
	
	// Update is called once per frame
	
	public void MoveUp(){
		//print("invokemovingup");
		max= true;
		//transform.Translate(Vector3.forward * Time.deltaTime);
		//transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}

	//refactor this and have it move based on adding the points via transorms and empty objects /// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other) {
//		if(other.gameObject.tag=="plr"){
//       // max = true;
//       print("movingup");
//		Invoke ("MoveUp" , 2);
//		}
		 if(other.gameObject.tag =="death"){
			Destroy(gameObject);
		}
		if(other.gameObject.tag =="up"){

			max= false;

		}
		else if(other.gameObject.tag =="down"){

			max= true;
		}
    }
	
}
//		if(this.transform.position.y >= -3.15  && this.transform.position.y <= 0.3 && max== false) {
//		transform.Translate(Vector3.forward * Time.deltaTime);
//		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
//			Debug.Log("max is false ");
//			if(this.transform.position.y >= -3.15 )
//		 		max = true;
// 		}else if(this.transform.position.y >= 0.3 && max == true){
//		transform.Translate(Vector3.back * Time.deltaTime);
//		transform.Translate(Vector3.down * Time.deltaTime, Space.World);
//			Debug.Log("max is true ");}