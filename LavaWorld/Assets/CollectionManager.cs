using UnityEngine;
using System.Collections;

public class CollectionManager : MonoBehaviour {

	

	void OnCollisionEnter2D(Collision2D coll){
		//if(coll.gameObject.tag =="Enem" ||coll.gameObject.tag =="Dmg"  || coll.gameObject.tag =="Ground" ){
		if(coll.gameObject.tag=="Player"){
		Debug.Log("Colliding wirth payer");
					Destroy(gameObject);
					PlayerStatus.increamentBullets();

					}


	}


}
