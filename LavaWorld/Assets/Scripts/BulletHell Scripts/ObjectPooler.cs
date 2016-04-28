using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// an object pooler based on lists // to grow if needed - soon used to pool spec objects assigned in inspector 
///did not create a dictionary - no need for this small game for now /// not alot of insta at run time
/// </summary>
public class ObjectPooler : MonoBehaviour {

	public GameObject myPooledObject;
	public int Size=5;
	public static ObjectPooler mypooler;

	public List<GameObject> pooledObjectS;
	// Use this for initialization
	void Start () {

		pooledObjectS = new List<GameObject>();//creates ab emoty list 
		for( int i = 0; i < Size; i++){

			GameObject obj = Instantiate(myPooledObject) as GameObject;
			obj.SetActive(false);
			pooledObjectS.Add(obj);
		}
	}
	


	public GameObject RetrivePooledObject()
	{

		for ( int i = 0 ; i<pooledObjectS.Count; i++){

			if(!pooledObjectS[i].activeInHierarchy){

				return pooledObjectS[i];

			}
		}
			//if it is empty create more// or objects are in use create more and add it to the list  
		GameObject obj = Instantiate(myPooledObject) as GameObject;
		obj.SetActive(false);
		pooledObjectS.Add(obj);

		return obj;


		

		}///end of method 


		}
		




//		for ( int i= 0; i< pooledObjectS.Count; i++)
//		{
//
//			if( !pooledObjectS[i].activeInHierarchy){
//
//				return pooledObjectS[i];//retun object that is not active 
//
//				}
//
//			GameObject obj = Instantiate(myPooledObject) as GameObject;
//			obj.SetActive(false);
//			pooledObjectS.Add(obj);
//
//			return obj;
//			
//
//
//			}
		
