using UnityEngine;
using System.Collections;
/// <summary>
/// simply moves the enmeydown down  on y axsis 
/// </summary>
public class MoveDownwards : MonoBehaviour {
	Rigidbody2D rgd;
	public float speed=0.5f;
	Animator anim;
	// Use this for initialization
	void Start () {
	rgd = GetComponent<Rigidbody2D>();
	anim = GetComponent<Animator>();
		//anim.Play("Enem1Entry");
	//	anim.applyRootMotion= false;
	//	Invoke("MoveFromScript", 1f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {



	rgd.velocity = new Vector2(0,-1) * speed;
	}

	public void MoveFromScript(){

	//	anim.applyRootMotion= true;

	}

}
