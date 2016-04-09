using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
public float timer = 60f;
LevelManager lvl;
	// Use this for initialization
	void Start () {
	lvl = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	timer -= Time.deltaTime;
//	Debug.Log(timer);



	if(timer<=0){
	timer=60;
	lvl.MoveToNextLevel();
	//lvl.GameOver();
	}
	}
}
