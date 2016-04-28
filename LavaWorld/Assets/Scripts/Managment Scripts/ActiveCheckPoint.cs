using UnityEngine;
using System.Collections;
/// <summary>
/// instant checkpoint effect
///bool was added for closing and opening flags but not used for now 
/// </summary>
public class ActiveCheckPoint : MonoBehaviour {

	public bool activeCheckpoint = false;
	public GameObject exp;


	void OnTriggerEnter2D(Collider2D other){
	if(other.gameObject.tag =="Player"){

			activeCheckpoint = true;
			if(exp!=null){
			Instantiate(exp, gameObject.transform.position, Quaternion.identity);}
	}

	}
}
