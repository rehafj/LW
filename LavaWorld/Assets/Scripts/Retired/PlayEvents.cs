using UnityEngine;
using System.Collections;

public class PlayEvents : MonoBehaviour {
	public Transform Truck;
	bool passedLevel = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( passedLevel)
			StartCoroutine(PlayTruckAnimation(2.0F));

	}


	//move this into n=move tonextlevelscript 

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.CompareTag("Player")){
			passedLevel = true;

	}
	}

	IEnumerator PlayTruckAnimation(float waitTime) {
		Truck.transform.Translate(transform.position.x +20, transform.position.y *Time.deltaTime, 0);
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
    }

}
