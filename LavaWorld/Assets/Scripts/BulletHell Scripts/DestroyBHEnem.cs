using UnityEngine;
using System.Collections;

public class DestroyBHEnem : MonoBehaviour {

public float lifeTime = 10f;
	// Use this for initialization
	void OnEnable () {

		Invoke( "Destroy", lifeTime);
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
