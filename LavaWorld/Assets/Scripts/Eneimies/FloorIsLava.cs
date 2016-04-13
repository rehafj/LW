using UnityEngine;
using System.Collections;

public class FloorIsLava : MonoBehaviour {
	PlayerStatus playerhealth;
	const int dmgbytime =2;
	// Use this for initialization
	void Start () {
		playerhealth = FindObjectOfType<PlayerStatus>();
	}
//	void OnTriggerStay2D(Collider2D other) {
//			if(other.gameObject.tag=="Player"){
//			Invoke("Subtracthealth",2f);
//			Debug.Log("entred floor is alva");
//			Debug.Log(playerhealth.health);
//			}
//
//
//	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
		InvokeRepeating("Subtracthealth",1,0.4f);

			//	Debug.Log("entred floor is alva");
//			Debug.Log(playerhealth.health);
//			}
    }}

	public void Subtracthealth(){
		playerhealth.health--;

	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
		//	Debug.Log("exiting trigger");

			CancelInvoke();
//			Debug.Log(playerhealth.health);
//			}
    }
 
    }


	//this can be used for knockback - intresting ! foorm unity exampes - api 
       // other.attachedRigidbody.AddForce(50F * other.attachedRigidbody.velocity);
}
