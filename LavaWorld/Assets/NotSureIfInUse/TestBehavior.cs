using UnityEngine;
using System.Collections;

public class TestBehavior : MonoBehaviour {
	public GameObject target;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
			target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = Vector3.Lerp(transform.position, target.transform.position, 0f);
		float step = speed * Time.deltaTime;
		if(target!=null)//check if player is not there other wise move down 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        else 
        transform.position = new Vector3(0f,-1f*Time.deltaTime,0f);

	}
}
