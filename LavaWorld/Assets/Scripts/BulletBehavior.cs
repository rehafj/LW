using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
//public int speed =9;
public Rigidbody2D myegd;
	// Use this for initialization
	void Start () {
	myegd = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

	//myegd.AddForce(Vector3.forward * speed);
		
		myegd.velocity = transform.TransformDirection(-Vector3.up * 15);
		myegd.AddForce(myegd.transform.up * 10);	}
}
