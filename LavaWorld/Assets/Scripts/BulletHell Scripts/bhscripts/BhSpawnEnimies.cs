using UnityEngine;
using System.Collections;

public class BhSpawnEnimies : MonoBehaviour {
	// Use this for initialization

	float randomXvalue;
	public float timer  = 2;
	float minX, maxX;
	ShipController myship;
	public ObjectPooler[] mypoolersOfEnemies;
	public Timer myBHcountDown;
	public float timerFastRespawn;
	public bool displayGui = false;
	//int timeCancled =0;

	//public GameObject[] enemyTypePollers;

	int randomEnemy;
	//temporarily disables the player through this script for 10 sec ( when the enimies start spawning, the player can move = its done here -> move this somehwere else better 
	void Start () {
		myship= FindObjectOfType<ShipController>();
		minX = transform.position.x - 8f;
		maxX = transform.position.x + 8f;
		myship.enabled=false;
		//Invoke("startRepeating",10f);//he time value is based on the timer we set up 
		StartCoroutine(BullerHellGame());
		myBHcountDown = FindObjectOfType<Timer>();
		if(myBHcountDown!=null){
			timerFastRespawn = myBHcountDown.timer;
		}


	}



	public void SpawnEnemies(){
		randomEnemy = Random.Range(0, mypoolersOfEnemies.Length);//stores a random enemy nuwmber (up to lastindex) 

		GameObject temp = mypoolersOfEnemies[randomEnemy].RetrivePooledObject();//gives acses to the ppoo for the ginafwm 

		
		//Quaternion tempRotation = new Quaternion
		//randomXvalue = Random.Range(minX, maxX);
		Vector3 tempPos = new Vector3(Random.Range(minX,maxX), transform.position.y, transform.position.z);

		temp.transform.position = tempPos;
		temp.transform.rotation = gameObject.transform.rotation;
	//	Debug.Log("setting enemy to active  ");

		temp.SetActive(true);
			//if(temp==null)
		//return ;

		}


	void startRepeating(){
		

		InvokeRepeating("SpawnEnemies",timer,timer);
		if( timer<3){
		Debug.Log("Timer was reduced!");
		}
		}


IEnumerator	BullerHellGame(){

		yield return new WaitForSeconds(10f);//counts to `0 seconds 
		myship.enabled=true;
		Invoke("startRepeating",0f);//he time value is based on the timer we set up 
		yield return new WaitForSeconds(10);
		CancelInvoke();
		timer = 2; 
		Invoke("startRepeating",0f);//he time value is based on the timer we set up 
		yield return new WaitForSeconds(5);//second phase lasts for 
		CancelInvoke();
		Debug.Log("cancled invoke for "+ Time.deltaTime);
		displayGui= true;
		yield return new WaitForSeconds(7);
		displayGui= false;
		timer =1.5f;
		Invoke("startRepeating",0f);//he time value is based on the timer we set up 

}


	void OnDisable() {
		CancelInvoke();
    }

	void OnGUI() {
	if(displayGui){

			if (Time.time % 2 < 1) {
				GUI.Box(new Rect (100,100,200,20), "Large Wave incoming") ;
            }

	}
     
    }



}



	
	// Update is called once per frame


//	public void SpawnEnemies(){
//	GameObject temp = Pooler.currentPoller.returnRandomEnmey();//gives acses to the ppoo for the ginafwm 
//
//	if(temp==null)
//	return ;
//	//Quaternion tempRotation = new Quaternion
//	//randomXvalue = Random.Range(minX, maxX);
//	Vector3 tempPos = new Vector3(Random.Range(minX,maxX), transform.position.y, transform.position.z);
//	temp.transform.position = tempPos;
//	temp.transform.rotation = gameObject.transform.rotation;
////	Debug.Log("setting enemy to active  ");
//
//	temp.SetActive(true);
//
//
//	}
//
//void Update(){
////	if(myBHcountDown!=null){
////			Debug.Log(timeCancled);
////
////			timerFastRespawn-=Time.deltaTime;
////			if(timerFastRespawn<=30f && timerFastRespawn>=20f){
////				if(timeCancled==0){
////					CancelInvoke("SpawnEnemies");
////					timeCancled++;
////				}
////				timer = 2f;
////				if(timeCancled==1){
////					Invoke("startRepeating",0f);
////					timeCancled++;
////					}
////
////			if(timerFastRespawn<=15f && timerFastRespawn>=10f){
////
////				displayGui = true;
////				if(timeCancled==3){
////						CancelInvoke("SpawnEnemies");
////						timeCancled++;}
////					}//time between 15 and 10 nothing is showing just the blinking text then spawn again 
////				else {
////					displayGui= false;
////						if(timeCancled==4){
////							timer = 1f;
////							Invoke("startRepeating",0f);
////							timeCancled++;}
////							}
////
////			} 
////
////	}
//}