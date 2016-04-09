using UnityEngine;
using System.Collections;

public class DestroyBHEnem : MonoBehaviour {


	// Use this for initialization
	void OnEnable () {

	Invoke( "Destroy", 8f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void Destroy (){

	gameObject.SetActive(false);
	}

	void OnDisable(){

	CancelInvoke();
	}
}
