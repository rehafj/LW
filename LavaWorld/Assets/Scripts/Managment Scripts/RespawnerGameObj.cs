using UnityEngine;
using System.Collections;

public class RespawnerGameObj : MonoBehaviour {
/// <summary>
/// returns gameobject this script is attacjed to to their origitanl state 
///have o hange code that 'destroys them' into code that deactivates them... -> check other files to fix this
/// </summary>
Vector3 iniitalPostion;
Quaternion initialRotation;
Vector3 intialScale;
Rigidbody2D initialRidgidbody;
//GameObject instance;

	// Use this for initialization
	void Start () {
	//instance = GetComponent<GameObject>();

//	if(this.isActiveAndEnabled== true){
//	gameObject.SetActive(false);
//
//	}
	iniitalPostion = transform.position;
	initialRotation = transform.rotation;
	intialScale = transform.localScale;

	if(gameObject.GetComponent<Rigidbody2D>()!=null){

	initialRidgidbody = GetComponent<Rigidbody2D>();
	}

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ResetDefaultpostions(){

	transform.position = iniitalPostion;
	initialRotation = transform.rotation;
	transform.localScale = intialScale;

		if(initialRidgidbody!=null){

			initialRidgidbody.velocity= Vector3.zero;
		}
	}
}
