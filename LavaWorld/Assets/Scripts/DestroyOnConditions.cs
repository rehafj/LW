using UnityEngine;
using System.Collections;
/// <summary>
/// this script will handle destruciton of things - so far it just destroys objects based on timer we give it to and a boolian value we can manipluate 
///THIS SCRIPT WIL BE REWTITTEN - DEPENING ON OBJECT IF BULLETS MOSTLY WILL BE TURNED INTO DEACTIVATE AND WE WILL USE OBECT OOOLING STAYTUNED~ ops sorry caps 
/// </summary>
public class DestroyOnConditions : MonoBehaviour {

public bool DestroyafterTime= true; //intially wil destory the object after time
public float lifeTime =10;
	// Use this for initialization
	void Awake () {
		InititateObjectDestruction();//temproary destoy as soon as it is awake - testing
	}
	


	public void InititateObjectDestruction(){

		if( DestroyafterTime== true){
		Destroy(gameObject,lifeTime);
	}
	}
		 void OnTriggerEnter2D(Collider2D col){
		 if(col.gameObject.tag=="Water"){

		 Destroy(gameObject);
		 }

		 }


}