using UnityEngine;
using System.Collections;

public class IheratedPooler : MonoBehaviour {

	//public GameObject[]whattocreate;
	public GameObject[] whattocreate = new GameObject[5];
	public	int HowManyodEachType ;
	public int counter=0;
	public GameObject[] types;
//public int NumberOfBulletTypes;
/// <summary>
/// This is not right - will fix later - just a quick hack - I know issues ...
/// </summary>
//	// Use this for initialization
	void Start () {
	for( int i=0; i< whattocreate.Length;i++){
		CreateEnemyBullets(whattocreate[i], counter);
//		Debug.Log(whattocreate[i]);

	}

	}
//		ReturnEnemyBulletsI(0);
//
//	//	CreateEnemyBullets();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//
public  void CreateEnemyBullets(GameObject createdObject, int counter){
		//for( int i=0; i< whattocreate.Length;i++){

			types = new GameObject[HowManyodEachType];

			for ( int j = 0 ; j< HowManyodEachType; j++){
				GameObject temp = Instantiate(createdObject);//create an instance of an pbject 
				temp.SetActive(false);
				types[j] = temp;
			}
//		//	EnemyBullets[i] = temp;//add it to the array 
	}
	//}
//
//	public   GameObject ReturnEnemyBulletsI(int index){
//
//		}

}


