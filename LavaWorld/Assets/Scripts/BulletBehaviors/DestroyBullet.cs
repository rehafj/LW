using UnityEngine;
using System.Collections;
/// <summary>
/// this is used with bullets or objects that are used with the pooler // sets them to deactive instead of destroying them 
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
