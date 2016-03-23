using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {
ParticleSystem p;
	// Use this for initialization
	void Start () {
		p = gameObject.GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){

//(gameObject, 5);

	}
}
