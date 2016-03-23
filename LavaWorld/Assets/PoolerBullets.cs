using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PoolerBullets: MonoBehaviour {
/// <summary>
/// just for testing
/// </summary>

	public GameObject bullet; 
	public int num_bullets=4;
	public float timer = 2f;

	public GameObject []bullets;
	//List < GameObject> enemies;
	// Use this for initialization
	void Start () {
	bullets = new GameObject[num_bullets];
	for( int i = 0; i< num_bullets; i++){
	GameObject temp = Instantiate(bullet);
	temp.SetActive(false);
	bullets[i] = temp;
	}

	//enemies = new List<GameObject>();
	//for( int i = 0; i< num_bullets; i++){
	//GameObject temp = Instantiate(bullet);
	//temp.SetActive(false);
	//enemies.Add(temp);

	//}

		InvokeRepeating("startss",timer,timer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void startss(){
	//	for(int i = 0 ; i<enemies.Count;i++){
	for( int i = 0 ; i< bullets.Length; i++){

		if(!bullets[i].activeInHierarchy)
		{
		bullets[i].transform.position = transform.position;
		bullets[i].transform.rotation = transform.rotation;
		bullets[i].SetActive(true);
		break;
		}
	}
		}

	}

