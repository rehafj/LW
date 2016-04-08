using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour {

	public GameObject[] test;
	public  RespawnerGameObj[] spawningThese;
	int index; 
	// Use this for initialization
	void Start () {



	///change this code based on camera view and set them to axctive vs inactive -- does not work - camera handles rendering and not activation
	//cant activate what it cant c 
	//consider activating children or trigger locations? 
		GameObject.FindObjectOfType<RespawnerGameObj>();
		index= spawningThese.Length;
		spawningThese = FindObjectsOfType<RespawnerGameObj>();
	for( int i = 0; i< spawningThese.Length; i++){
		if (spawningThese[i].gameObject.activeSelf== true){//change false to true but on rendereer spectrun thing 
//				print(spawningThese[i].gameObject.name);
				spawningThese[i].gameObject.SetActive(true);
		}
}


	}
	// Update is called once per frame
	void Update () {

//		for( int i = 0; i< spawningThese.Length; i++){
//			if(Camera.current != null) {
//                     Vector3 pos = Camera.current.WorldToViewportPoint(transform.position);//pos of the camea/view poer 
//				Debug.Log("created vector view ports");
//						
//                    if(pos.z > 0 && pos.x >= 0.0f && pos.x <=1.0f && pos.y >= 0.0f && pos.y <=1.0f) {//if it is witin the vamera's view set to active 
//                         //if(isDebug) Debug.Log (pos.ToString("F4"));
//					Debug.Log("entered within range");
//
//						spawningThese[i].gameObject.SetActive(true);
//						Debug.Log(spawningThese[i]+" is "+ spawningThese[i].isActiveAndEnabled);

                     }
//                 if(Camera.current != null) {
//                     Vector3 pos = Camera.current.WorldToViewportPoint(transform.position);//pos of the camea/view poer 
//
//                    if(pos.z > 0 && pos.x >= 0.0f && pos.x <=1.0f && pos.y >= 0.0f && pos.y <=1.0f) {//if it is witin the vamera's view set to active 
//                         //if(isDebug) Debug.Log (pos.ToString("F4"));
//						spawningThese[i].gameObject.SetActive(true);
//                     }
//                 }
             
	
	}

