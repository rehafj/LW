using UnityEngine;
using System.Collections;
/// <summary>
/// this class spawns bulllets that are used by enemy o= in BH - the speed can be tapred with to increase/decrease spawn rate publicly based on enemy type/prebfab
/// </summary>
public class SpawnBullets : MonoBehaviour {
public float timer=1;
//public ObjectPooler objpooler;
/// <summary>///
/// note to self... never read things at 4 am  
/// </summary>
	// Use this for initialization
//public GameObject myPooledgameObject; 
	void Start () {
		
//InvokeRepeating("LetLooseTheBullets",timer,timer);
	}

	void OnEnable(){
		InvokeRepeating("LetLooseTheBullets",timer,timer);

	}

	
	// Update is called once per frame


	public void LetLooseTheBullets(){//cz my naming gets crazy oh well :P 
	GameObject temp = Pooler.currentPoller.ReturnEnemyBullets();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;
	temp.SetActive(true);

	}


//
//	public void LetLooseTheBullets(){//cz my naming gets crazy oh well :P 
//
//	GameObject temp = objpooler.RetrivePooledObject();
//	temp.transform.position = gameObject.transform.position;
//	temp.transform.rotation = gameObject.transform.rotation;
//	temp.SetActive(true);
//	}
//

	void OnDisable() {
//        print("script was removed");
		CancelInvoke();
    }


}
