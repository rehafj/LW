using UnityEngine;
using System.Collections;


public class LavaEffects : MonoBehaviour {
//this script is a genral one that does  specfic dmg - it can be attached to damaging objects and we can modifty how many hits it takes to destory it 

//PlayerStatus MyPlayer;
	GameObject myPlayer;
	PlayerStatus playerStatusScript;
	PlayerController currentController;
	public int howMuchDamage = 10;					
	public int HitsToDestroy = 3;		 int initialHitsToDestory;
	//i.e. this object's health


	public bool instantKill = false;
	public bool canGetHit=true;
	public float timetoreswpan =5f;
	public bool wasDestroyed;
	RespawnerGameObj postion_gameobject;

public void Start(){

myPlayer = GameObject.FindGameObjectWithTag("Player");
playerStatusScript = myPlayer.GetComponent<PlayerStatus>();//TO MANAGE PLAYER HEALTH 
currentController = myPlayer.GetComponent<PlayerController>();//FOR KNOCKBACK 
initialHitsToDestory = HitsToDestroy;
postion_gameobject = GetComponent<RespawnerGameObj>();

}

void DestroyThis(){
	if(HitsToDestroy<=0){
			wasDestroyed = true;

		gameObject.SetActive(false);
		Invoke ("ResetEnemValues", timetoreswpan);
	}
		else 
		wasDestroyed = false;
}


void OnTriggerEnter2D( Collider2D coll){

//	if(coll.gameObject.tag=="Player"){
//			
//			if(instantKill){
//			playerStatusScript.resetVlues();
//			}
//			else
//				DoDamageToPlayer();
//
//	}
//
	 if( coll.gameObject.tag=="Water" && canGetHit ==false){
			Debug.Log(" monster was hit and can get hit was false ");
			HitsToDestroy-=1;
			DestroyThis();
	}
	else if( coll.gameObject.tag=="Water" && canGetHit ==true)
			Debug.Log(" monster was hit and can get hit was true ");


}


	void OnCollisionEnter2D( Collision2D coll){

	if(coll.gameObject.tag=="Player"){
			
			if(instantKill){
			playerStatusScript.resetVlues();
			}
			else{
				DoDamageToPlayer();
			}

	}

	else if( coll.gameObject.tag=="Water" && canGetHit ==false){
			Debug.Log(" monster was hit and can get hit was false ");
			HitsToDestroy-=1;
			DestroyThis();
	}
		else if( coll.gameObject.tag=="Water" && canGetHit ==true)
			Debug.Log(" monster was hit and can get hit was true ");


}



//chaneg this inside the player script status  - better anbd change ti to recive dmg -> call it from here 
public void DoDamageToPlayer(){

	 	playerStatusScript.GetDamageFromFire(howMuchDamage);
//		currentController.KnockBack();
}

public bool RetrunWasDestroyed (){

		return wasDestroyed;
}

public void  ResetEnemValues(){
		gameObject.SetActive(true);
		HitsToDestroy = initialHitsToDestory;
		postion_gameobject.ResetDefaultpostions();//returns in to its original postion 

}



}
