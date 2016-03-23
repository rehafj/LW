using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
public int speed =3;
Rigidbody2D myegd;
	// Use this for initialization
	void Start () {
	myegd = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
	myegd.AddForce(transform.forward * speed);
	}
}
