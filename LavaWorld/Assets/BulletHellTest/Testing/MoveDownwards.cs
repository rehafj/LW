using UnityEngine;
using System.Collections;

public class MoveDownwards : MonoBehaviour {
	Rigidbody2D rgd;
	public float speed=0.5f;
	// Use this for initialization
	void Start () {
	rgd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	rgd.velocity = new Vector2(0,-1) * speed;
	}
}
