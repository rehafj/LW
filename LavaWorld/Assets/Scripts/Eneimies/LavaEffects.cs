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
	public bool CannotGetHit=false;
	public float timetoreswpan =5f;
	public bool wasDestroyed;
	RespawnerGameObj postion_gameobject;

	SpriteRenderer myImg;
	Color originalColor;
	public GameObject EnemyExp;

	public static int multip = 1;


public void Start(){

myPlayer = GameObject.FindGameObjectWithTag("Player");
playerStatusScript = myPlayer.GetComponent<PlayerStatus>();//TO MANAGE PLAYER HEALTH 
currentController = myPlayer.GetComponent<PlayerController>();//FOR KNOCKBACK Purpose 
initialHitsToDestory = HitsToDestroy;
postion_gameobject = GetComponent<RespawnerGameObj>();

		myImg = GetComponent<SpriteRenderer>();
		originalColor = myImg.color;

}

void DestroyThis(){
	if(HitsToDestroy<=0){
			wasDestroyed = true;
			if(EnemyExp!=null){
			Instantiate(EnemyExp,gameObject.transform.position, gameObject.transform.rotation);}
		gameObject.SetActive(false);
		Invoke ("ResetEnemValues", timetoreswpan);
	}
		else 
		wasDestroyed = false;
}


void OnTriggerEnter2D( Collider2D coll){

		if( coll.gameObject.tag=="Water" && CannotGetHit ==false){
			//Debug.Log(" monster was hit and can get hit was false ");
			HitsToDestroy-=1;
			if(HitsToDestroy>0){
			StartCoroutine("FlashEnemy",0f);}
			DestroyThis();
	}
		else if( coll.gameObject.tag=="Water" && CannotGetHit ==true)
			Debug.Log(" monster was hit and can get hit was true ");


	if(coll.gameObject.tag=="Player"){
			
			if(instantKill){
			playerStatusScript.resetVlues();
			}
			else{
				DoDamageToPlayer();
			}

	}
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

		else if( coll.gameObject.tag=="Water" && CannotGetHit ==false){
//			Debug.Log(" monster was hit and can get hit was false ");

			HitsToDestroy-=1;
			if(HitsToDestroy>0){
			StartCoroutine("FlashEnemy",0f);}
			DestroyThis();
	}
		else if( coll.gameObject.tag=="Water" && CannotGetHit ==true)
			Debug.Log(" monster was hit and can get hit was true ");


}



//chaneg this inside the player script status  - better anbd change ti to recive dmg -> call it from here 
public void DoDamageToPlayer(){

		playerStatusScript.GetDamageFromFire(howMuchDamage * multip);
//		currentController.KnockBack();
}

public bool RetrunWasDestroyed (){

		return wasDestroyed;
}

public void  ResetEnemValues(){
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

//			myImg.color = originalColor;
//			yield return new WaitForSeconds( 0.2f);
//			changeColorAlpha();
//			yield return new WaitForSeconds( 0.2f);
//			myImg.color = originalColor;


			//}




void changeColorAlpha(){
	Color temp = myImg.color;
	temp.a = 0;
	myImg.color = temp;
}




}

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