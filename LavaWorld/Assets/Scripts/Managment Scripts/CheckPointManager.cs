using UnityEngine;
using System.Collections;
/// <summary>
/// this script is placed on check points or similar objects 
/// it can be used with a level manager or a check point manager 
/// it sets whateve rcheck point we hit to the player's check point and overrides it 
// by settong the "this check point ar" from the inspector 
/// </summary>
public class CheckPointManager : MonoBehaviour {
public int thisCheckPoint =0;
public PlayerStatus player;

	// Use this for initialization
	void Start(){
		player = FindObjectOfType<PlayerStatus>();

	}


void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
		Debug.Log("collided with a check point");
			//Debug.LogError("it connected with checkpoint"+thisCheckPoint);
			player.currentPoint = this.thisCheckPoint;//sets it to what ever is in unity inspectpor 
			}

}}
