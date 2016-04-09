using UnityEngine;
using System.Collections;
/// <summary>
/// just for testing
/// </summary>
public class DestroyBullet : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {

	Invoke( "Destroy", 2f);
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
