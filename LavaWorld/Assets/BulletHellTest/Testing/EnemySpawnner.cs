using UnityEngine;
using System.Collections;

public class EnemySpawnner : MonoBehaviour {
public GameObject[] enemyTypes;
	// Use this for initialization
	void Start () {
	enemyTypes = GameObject.FindGameObjectsWithTag("Enem");
	for(int i = 0; i< enemyTypes.Length; i++){

	}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
