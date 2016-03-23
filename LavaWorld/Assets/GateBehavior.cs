using UnityEngine;
using System.Collections;

public class GateBehavior : MonoBehaviour {
Vector3 x;
Vector3 originalpos; 
public bool passed = false;
	// Use this for initialization
	void Start () {

	originalpos = gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator  MoveUp(){
	for(int i=0; i<10; i++){
		Vector3 temp = transform.position;
		temp.y+=1;//increase by wy pos
		transform.position=temp;

		yield return new WaitForSeconds(0.1f);
	}
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player"){
			if(passed==false){
			StartCoroutine(MoveUp());
			passed = true;
			}}
        
    }

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
		//print("eiting trigger gate");

		//Vector3 x = transform.position;
		//x.y-=7;//increase by wy pos
		//transform.position=x;	
		gameObject.transform.position = originalpos;	}
		passed=true;


    }
}
