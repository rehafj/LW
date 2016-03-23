using UnityEngine;
using System.Collections;
/// <summary>
/// old script - remove later 
/// </summary>
public class SetParetnentTrans : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other) {
     other.transform.parent = gameObject.transform;
    }

	void OnTriggerExit2D(Collider2D other)
    {
		other.transform.parent = null;
    }
     
}
