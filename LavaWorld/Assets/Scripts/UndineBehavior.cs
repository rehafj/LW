using UnityEngine;
using System.Collections;

public class UndineBehavior : MonoBehaviour {
	// Use this for initialization
    //remmeber\to deavtivate script and just hide it
	GameObject myPlayer;//i need ti cgane this 
	public GameObject prison;
	PlayerController status;
	 Animator Undine;
	public  Renderer img;

	void Start () {
		Undine = GetComponent<Animator>();
		myPlayer = GameObject.FindGameObjectWithTag("Player");
		status = myPlayer.GetComponent<PlayerController>();
		img = GetComponent<Renderer>();
		img.enabled = false;

		//status 
	}
	


	void OnTriggerEnter2D( Collider2D coll){

	if(coll.gameObject.tag=="Player"){
			img.enabled = true;
			status.FoundWater = true;
			Undine.Play("Undine");

}
}
}
