using UnityEngine;
using System.Collections;
using Fungus;
/// <summary>
/// just displays uidine and enables player water 
/// </summary>
public class UndineBehavior : MonoBehaviour {
	// Use this for initialization
    //remmeber\to deavtivate script and just hide it
	GameObject myPlayer;//i need ti cgane this 
	public GameObject prison;
	public PlayerController status;
	public PlayerController myPlayerTest;
	 Animator Undine;
	public  Renderer img;

	void Start () {
		Undine = GetComponent<Animator>();
		myPlayerTest = FindObjectOfType<PlayerController>();
		myPlayer = GameObject.FindGameObjectWithTag("Player");
		status = myPlayer.GetComponent<PlayerController>();
		img = GetComponent<Renderer>();
		img.enabled = false;

		//status 
	}
	


	void OnTriggerEnter2D( Collider2D coll){
		//Debug.Log("collided");

	if(coll.gameObject.tag=="Player"){
			status.FoundWater = true;
			//myPlayerTest.FoundWater = true;
			Debug.Log("collided");
			img.enabled = true;
			Undine.Play("Undine");

}
}
}
