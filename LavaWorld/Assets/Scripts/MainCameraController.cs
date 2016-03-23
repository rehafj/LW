using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	// Use this for initialization
	//public Vector3 postionI; 
	//public Vector3 targetPos;
	public GameObject PlayerPostion;
	PlayerController playerdirection;
	public Vector3 targetlocation ;
	void Start () {
		PlayerPostion = GameObject.FindGameObjectWithTag("Player");
		playerdirection = PlayerPostion.GetComponent<PlayerController>();
		//PlayerPostion = PlayerPostion.GetComponent<GameObject>();

	}
	/// <summary>
	/// do you guys want this script - just adds space infront of the player - or we can manually go and change the x value and just have lerp here - notetoself
	/// </summary>
	
	// Update is called once per frame
	void Update () {//// if our camera is not a child we can implement ths not oto show the flow but we habe tp scale it right amd this will save the y pos of the camera 
	///right not its relative to the player 

				targetlocation = new Vector3(PlayerPostion.transform.position.x , transform.position.y, transform.position.z);

		if(playerdirection.isFacingRight){
			//transform.position 
			targetlocation = new Vector3(PlayerPostion.transform.position.x + 2, transform.position.y, transform.position.z);

			}
		else if ( !playerdirection.isFacingRight){
			targetlocation = new Vector3(PlayerPostion.transform.position.x - 2, transform.position.y, transform.position.z);
			transform.position =  Vector3.Lerp(transform.position, targetlocation, 2f * Time.deltaTime);
			}
		
			}

}
