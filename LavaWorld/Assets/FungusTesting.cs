using UnityEngine;
using System.Collections;
using Fungus;
public class FungusTesting : Flowchart {
public Flowchart myflowchart;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D( Collider2D coll){

	if(coll.gameObject.tag=="Player"){
			
			SendFungusMessage("Test");
	

}
}

}
