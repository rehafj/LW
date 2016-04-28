using UnityEngine;
using System.Collections;
/// <summary>
/// this script destorys objects based on lifetime / used with things that do not use a pooler or instaniates // untill we fix all links across the game 
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
		 //test


}