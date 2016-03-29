using UnityEngine;
using System.Collections;


public class PoolerTestingNew : MonoBehaviour {

public static PoolerTestingNew instance;

void Awake(){

if(instance == null){

			GameObject newpool = new GameObject("PoolerTestingNew");
			newpool.AddComponent<PoolerTestingNew>();
		
}
else {
	instance = this;
}

}}
