using UnityEngine;
using System.Collections;
//this is a cool script that simply looks at the player moving we can attack this to a camer at the end ogf the level 
// not needed band may not work but i like its effect:P 
public class LookAt : MonoBehaviour {
public Transform target;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	transform.LookAt(target);
	}
}
