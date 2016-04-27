using UnityEngine;
using System.Collections;

public class MoveToNextLevel : MonoBehaviour {

	public LevelManager mamage;
	public bool canMove = false;
	public int nextLevel;
	// Use this for initialization
	void Start () {
	mamage = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll){
	if(coll.gameObject.CompareTag("Player")){ //&& canMove==true){

		//mamage.MoveToNextLevel();
			mamage.MoveToSelevtedLevel(nextLevel);
	}

		

	}
}
