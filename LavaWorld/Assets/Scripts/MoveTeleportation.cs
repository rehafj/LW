using UnityEngine;
using System.Collections;
/// <summary>
/// a veruy small portal that moves whatever it touches from point a to point b - note can work on any collider even bullets 
/// </summary>
public class MoveTeleportation : MonoBehaviour {

public Transform pointA;
public Transform pointB;


	void OnTriggerEnter2D(Collider2D other) {
        //if hits portal one go to portal two 
		//if(currentPos == pointB.transform.position){
		//Invoke("Telaport(other)",1);
        other.transform.position = pointB.transform.position;
        //if(currentPos == pointB.transform.position){
			//other.transform.position = pointA.transform.position;

        }


        }

	//StartCoroutine(Telaport(other, 1f));

//	IEnumerator  Telaport(Collider2D other, float waitTime){
//		yield return new WaitForSeconds(waitTime);
//		other.transform.position = pointB.transform.position;
	//	}//public Transform Player;

//public Vector3 currentPos;//temp tp assign 

	// Use this for initialization
	//void Start () {


//	currentPos = this.transform.position;

//	}
	
	// Update is called once per frame
	//void Update () {
//
//	currentPos =  Player.transform.position;
//		Debug.Log(Player.transform.position);
	//}




