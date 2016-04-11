using UnityEngine;
using System.Collections;

public class BhSpawnEnimies : MonoBehaviour {
	// Use this for initialization

	float randomXvalue;
	public float timer  = 2;
	float minX, maxX;
	ShipController myship;
	void Start () {
		myship= FindObjectOfType<ShipController>();
		minX = transform.position.x - 6f;
		maxX = transform.position.x + 6f;
		myship.enabled=false;
		Invoke("startRepeating",10f);
	//	InvokeRepeating("SpawnEnemies",timer,timer);
	}

	void OnEnable(){
		//InvokeRepeating("SpawnEnemies",timer,timer);

	}

	
	// Update is called once per frame


	public void SpawnEnemies(){
	GameObject temp = Pooler.currentPoller.returnRandomEnmey();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;
	//Quaternion tempRotation = new Quaternion
	//randomXvalue = Random.Range(minX, maxX);
	Vector3 tempPos = new Vector3(Random.Range(minX,maxX), transform.position.y, transform.position.z);
	temp.transform.position = tempPos;
	temp.transform.rotation = gameObject.transform.rotation;
//	Debug.Log("setting enemy to active  ");

	temp.SetActive(true);


	}
	void startRepeating(){
		myship.enabled=true;

	InvokeRepeating("SpawnEnemies",timer,timer);}


	void OnDisable() {
		CancelInvoke();
    }
}
