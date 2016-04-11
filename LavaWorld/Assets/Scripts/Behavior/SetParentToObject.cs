using UnityEngine;
using System.Collections;
/// <summary>
/// this class sets whatever object its atached to as a parent - 
///this can be used within platforms that are moving so that the player can move along with it 
///( sets player as child of the object the script it attached to )
/// </summary>
public class SetParentToObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
	if(other.gameObject.tag=="Player"){
     other.transform.parent = gameObject.transform;
    }}

	void OnTriggerExit2D(Collider2D other)
	{if(other.gameObject.tag=="Player"){
		other.transform.parent = null;}
    }}


