using UnityEngine;
using System.Collections;

public class CurrentCheckpoint : MonoBehaviour {


//public int thisCheckPoint =0;
public bool passedCheckPoint;
public PlayerStatus player;

	// Use this for initialization
	void Start(){
		player = FindObjectOfType<PlayerStatus>();

	}


void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
		Debug.Log("collided with a check point");
			//Debug.LogError("it connected with checkpoint"+thisCheckPoint);
		//	player.currentPoint = this.thisCheckPoint;//sets it to what ever is in unity inspectpor 
			}
			}}
