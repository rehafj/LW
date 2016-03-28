using UnityEngine;
using System.Collections;

public class SpawnBullets : MonoBehaviour {
public float timer=1;
/// <summary>
/// test this oout and read more about pooling objects :D note to self... never read things at 4 am  
/// </summary>
	// Use this for initialization
//public GameObject myPooledgameObject; 
	void Start () {
		
InvokeRepeating("LetLooseTheBullets",timer,timer);
	}

	void OnEnable(){
		InvokeRepeating("LetLooseTheBullets",timer,timer);

	}

	
	// Update is called once per frame


	public void LetLooseTheBullets(){//cz my naming gets crazy oh well :P 
	GameObject temp = TestingPollingGeneric.currentPoller.ReturnPooledObect();//gives acses to the ppoo for the ginafwm 

	if(temp==null)
	return ;

	temp.transform.position = gameObject.transform.position;
	temp.transform.rotation = gameObject.transform.rotation;
	temp.SetActive(true);

	}


	void OnDisable() {
        print("script was removed");
		CancelInvoke();
    }


}
