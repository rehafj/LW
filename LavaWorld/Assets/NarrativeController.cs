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

	public void   ActivatePlayerPlatform(){
		plr.enabled= true;

	}
}
