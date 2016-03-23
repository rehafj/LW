using UnityEngine;
using System.Collections;

public class patternA : MonoBehaviour {

public bool p1=false ;
public int x = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	while(p1){
	transform.Rotate(0,x,0);
	}

	}
}
