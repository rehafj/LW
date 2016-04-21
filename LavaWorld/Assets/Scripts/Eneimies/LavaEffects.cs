using UnityEngine;
using System.Collections;


public class LavaEffects : MonoBehaviour {
//this script is a genral one that does  specfic dmg - it can be attached to damaging objects and we can modifty how many hits it takes to destory it 

	GameObject myPlayer;
	PlayerStatus playerStatusScript;
	PlayerController currentController;

	public int howMuchDamage = 10;					
	public int HitsToDestroy = 3;		public int initialHitsToDestory;//just for inheritance test
	//i.e. this object's health


	public bool instantKill = false;
	public bool CannotGetHit=false;
	public float timetoreswpan =5f;
	public bool wasDestroyed;

	RespawnerGameObj postion_gameobject;
	public ShipController truck;

	SpriteRenderer myImg;
	Color originalColor;
	public GameObject EnemyExp;

	public static int multip = 1;

	AudioSource sound;

	 DropItems canDropItem;

	 int damageTaken = 1;

public void Start(){
//said something stupid Here 
	myPlayer = GameObject.FindGameObjectWithTag("Player");
	if(myPlayer!=null){//if issues remove this 
		playerStatusScript = myPlayer.GetComponent<PlayerStatus>();//TO MANAGE PLAYER HEALTH 
		currentController = myPlayer.GetComponent<PlayerController>();
		truck = myPlayer.GetComponent<ShipController>();
	}
	HitsToDestroy = HitsToDestroy * multip; // htis is if it is needed for multiplayer on health value 
	initialHitsToDestory = HitsToDestroy;
	postion_gameobject = GetComponent<RespawnerGameObj>();

	myImg = GetComponent<SpriteRenderer>();
	originalColor = myImg.color;

	sound = GetComponent<AudioSource>();


		canDropItem = GetComponent<DropItems>();}




void OnTriggerEnter2D( Collider2D coll){

		if(coll.gameObject.tag=="Player"){
			
			PlayerEffects();

		}	if( coll.gameObject.tag=="SP" && CannotGetHit ==false){
			damageTaken=2;
			EnemyTakeDamage(damageTaken);

				}

	
		if( coll.gameObject.tag=="Water" && CannotGetHit ==false){
			damageTaken=1;
			EnemyTakeDamage(damageTaken);

				}

		else if( coll.gameObject.tag=="Water" && CannotGetHit ==true)
			Debug.Log(" Cannot get hit / do something here if you want to // do wewant anything to happen?");

}


void OnCollisionEnter2D( Collision2D coll){

	if(coll.gameObject.tag=="Player"){
			
			PlayerEffects();

	}

		else if( coll.gameObject.tag=="Water" && CannotGetHit ==false){

			EnemyTakeDamage(damageTaken);
	}
		else if( coll.gameObject.tag=="Water" && CannotGetHit ==true)
			Debug.Log(" monster was hit and can get hit was true ");//for enemies like bLOB


}



//chaneg this inside the player script status  - better anbd change ti to recive dmg -> call it from here 
public void DoDamageToPlayer(){
	if(howMuchDamage>0){// remove this later - quick fix for sandao platfrom sub
			if( currentController!= null && !currentController.cantGetHurt){
				if(playerStatusScript.health>10){
					Debug.Log("health is "+playerStatusScript.health+"doing knockback!");//to prevent knockback if player has last 10 hp ( no kb on reset) 
					currentController.KnockBack();}
				playerStatusScript.GetDamageFromFire(howMuchDamage * multip);}
			else if ( truck!=null && !truck.cantGetHurt){
				truck.CheckInvinibility();
				playerStatusScript.GetDamageFromFire(howMuchDamage * multip);
				}

		}
}


public bool RetrunWasDestroyed (){

		return wasDestroyed;
}

public virtual void  ResetEnemValues(){ //for the future need to override this becuase enemyies are based on random and if this is ued in bh part = issues respawns same place but we need an ovverride to reset values only and not pos 
		wasDestroyed = false;
		gameObject.SetActive(true);
		HitsToDestroy = initialHitsToDestory;
		if(postion_gameobject!=null){
		postion_gameobject.ResetDefaultpostions();//returns in to its original postion 
		}
}



IEnumerator  FlashEnemy(float waittime){
	for(int i = 0 ; i < 2; i++){

			changeColorAlpha();
			yield return new WaitForSeconds( 0.1f);
			myImg.color = originalColor;
			yield return new WaitForSeconds( 0.1f);


			}}




void changeColorAlpha(){
	Color temp = myImg.color;
	temp.a = 0;
	myImg.color = temp;
}

void PlayerEffects(){

		if(instantKill){
			playerStatusScript.resetVlues();
			}
			else{
				DoDamageToPlayer();
			}


}

void EnemyTakeDamage(int dmg){


			HitsToDestroy-=dmg;
			if(HitsToDestroy>0){
				StartCoroutine("FlashEnemy",0f);}
			DestroyThis();

}


void DestroyThis(){
	if(HitsToDestroy<=0){
			wasDestroyed = true;

			if(EnemyExp!=null){
				Instantiate(EnemyExp,gameObject.transform.position, gameObject.transform.rotation);}

			if(canDropItem!=null){
				canDropItem.DropCollectable();
			}
			
		gameObject.SetActive(false);
		Invoke ("ResetEnemValues", timetoreswpan);
	}
		else 
		wasDestroyed = false;
}

}

//			myImg.color = originalColor;
//			yield return new WaitForSeconds( 0.2f);
//			changeColorAlpha();
//			yield return new WaitForSeconds( 0.2f);
//			myImg.color = originalColor;


			//}



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