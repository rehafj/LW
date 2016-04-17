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
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

	}
}
