using UnityEngine;
using System.Collections;
/// <summary>
/// inc the static counter of b=special bullets as they travelw ith the player and destorys the obj at the moemnt - did not add a pooler for it 
///quick fix
/// </summary>
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
