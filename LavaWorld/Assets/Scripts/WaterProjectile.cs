using UnityEngine;
using System.Collections;

public class WaterProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {

	Destroy(gameObject, 0.8f);
	}
	/// <summary>
	/// temporary sulotion untill we unify adn c how things go 
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnCollisionEnter2D(Collision2D coll){
		//if(coll.gameObject.tag =="Enem" ||coll.gameObject.tag =="Dmg"  || coll.gameObject.tag =="Ground" ){
		if(coll.gameObject.tag!="Player")
					Destroy(gameObject);

	}//}//TODO add behavior to bullets so that they do dmg on contact to objects 
//	void OnTriggerEnter2D(Collider2D coll){
//		if(coll.gameObject.tag !="Player"){
//				Destroy(gameObject);
//
//	}

	}



//	void OnTriggerEnter2D(Collider2D c){
//
//	Destroy(gameObject);
//		print("destroyedin trigger");
//	}
//
//	void OnCollisionEnter2D(Collision2D c){
//
//	Destroy(gameObject);
//	print("destroyedin col");
//	}

