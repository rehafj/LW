using UnityEngine;
using System.Collections;


public class LavaEffects : MonoBehaviour {
//this script is a genral one that does  specfic dmg - it can be attached to damaging objects and we can modifty how many hits it takes to destory it 

//PlayerStatus MyPlayer;
	GameObject myPlayer;
	PlayerStatus playerStatusScript;
	public int howMuchDamage = 10;
	public int HitsToDestroy = 3;//i.e. this object's health 
	public bool instantKill = false;

	public bool wasDestroyed;


public void Start(){

myPlayer = GameObject.FindGameObjectWithTag("Player");
playerStatusScript = myPlayer.GetComponent<PlayerStatus>();

}

void DestroyThis(){
	if(HitsToDestroy<=0){
		//add playing animaiton/explotion steam whatever - public so we can modify it based on current item  
			wasDestroyed = true;

		Destroy(gameObject, 1);
	}
		else 
		wasDestroyed = false;
}


void OnTriggerEnter2D( Collider2D coll){

	if(coll.gameObject.tag=="Player"){
			
			if(instantKill){
			playerStatusScript.resetVlues();
			}
			else
				DoDamageToPlayer();

	}

	else if( coll.gameObject.tag=="Water"){

			HitsToDestroy-=1;
			DestroyThis();
	}

}


	void OnCollisionEnter2D( Collision2D coll){

	if(coll.gameObject.tag=="Player"){
			
			if(instantKill){
			playerStatusScript.resetVlues();
			}
			else
				DoDamageToPlayer();

	}

	else if( coll.gameObject.tag=="Water"){

			HitsToDestroy-=1;
			DestroyThis();
	}

}


//chaneg this inside the player script status  - better anbd change ti to recive dmg -> invoke it from here 
public void DoDamageToPlayer(){

	 	playerStatusScript.GetDamageFromFire(howMuchDamage);
		//Debug.Log("changed health value it is now "+ playerStatusScript.health);

}

public bool RetrunWasDestroyed (){

		return wasDestroyed;
}


}
