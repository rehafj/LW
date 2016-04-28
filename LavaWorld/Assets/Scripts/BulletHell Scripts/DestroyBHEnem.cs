using UnityEngine;
using System.Collections;
/// <summary>
/// Destroy BH enem. - deactivates an enemy in BH after a lifespan - this script maybe a aduplicate check if same logic is used somewhere /// quick fix 
/// </summary>
public class DestroyBHEnem : MonoBehaviour {

public float lifeTime = 10f;
	// Use this for initialization
	void OnEnable () {

		Invoke( "Destroy", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void Destroy (){

	gameObject.SetActive(false);
	}

	void OnDisable(){

	CancelInvoke();
	}
}
