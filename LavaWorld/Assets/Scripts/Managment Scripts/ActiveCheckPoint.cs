using UnityEngine;
using System.Collections;

public class ActiveCheckPoint : MonoBehaviour {

	public bool activeCheckpoint = false;



	void OnTriggerEnter2D(Collider2D other){
	if(other.gameObject.tag =="Player"){

			activeCheckpoint = true;
	}

	}
}
