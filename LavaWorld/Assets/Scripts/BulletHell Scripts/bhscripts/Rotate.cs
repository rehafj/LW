using UnityEngine;
using System.Collections;
/// <summary>
/// this was removed - it siply rotates the enemy and spawns bullets on 90 degree angles ( like a cross pattern) used wotj rotar prefab
/// </summary>
public class Rotate : MonoBehaviour {
public float zValue = 90;
	// Use this for initialization
	void Start () {
	InvokeRepeating("RotateByFixefdAngle",0f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void RotateByFixefdAngle(){

	transform.Rotate(0,0,zValue);
	}

}
