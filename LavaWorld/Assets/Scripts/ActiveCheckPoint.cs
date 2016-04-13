using UnityEngine;
using System.Collections;

public class ActiveCheckPoint : MonoBehaviour {

	public bool activeCheckpoint = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
	if(other.gameObject.tag =="Player"){

			activeCheckpoint = true;
	}

	}
}
