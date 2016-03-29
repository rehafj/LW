using UnityEngine;
using System.Collections;
using Fungus;

public class NarrativeController : MonoBehaviour {
public PlayerController plr;
	// Use this for initialization
	void Start () {
	plr = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// call this at the end of any flow chart and set the 
	//collider of that flow chart to disable the player (y) or later ill 
	//add something here to better control it and have it in a single script
	///not good having it scattred like this - but this is just for testing for now 


	public void   ActivatePlayerPlatform(){
		plr.enabled= true;

	}
}
