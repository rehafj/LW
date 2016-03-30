using UnityEngine;
using System.Collections;
using Fungus;
public class FungusTesting : Flowchart {
//public Flowchart myflowchart;
public PlayerController plr;
	// Use this for initialization

	void Start(){
	plr = FindObjectOfType<PlayerController>();

	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D( Collider2D coll){

	if(coll.gameObject.tag=="Player"){
			
			SendFungusMessage("Test");
			plr.enabled =false;

}
}

}
