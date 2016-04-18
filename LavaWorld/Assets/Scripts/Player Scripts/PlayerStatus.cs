using UnityEngine;
using System.Collections;

/// <summary>
/// Pthis script manages all things player status - currenlt it checks for player health, lives and resets .etc 
///for now this script holds check points however this may be moved onto its own script or with scene manager script -
/// however this is used in conjunciton scripts such as checkpoints( resets thiisvalue to last check point visted) 
///and some scripts that deal damage to player - os managed by a method here or via tag for base dmg (if we forgot to script anything!)
/// </summary>
//move shared componenets into a level manager -> 
public class PlayerStatus : MonoBehaviour {

	//public   PlayerStatus Playerinstance;
	public LevelManager currentScene;
	//public static PlayerStatus PlayerinstanceTest;
	/// player status var 
	public int health;
	public int lives;
	//int maxHealth = 100;
	// current player position and animator 
	public Transform Player ;
	public Animator anim;
	public GameObject particleexp;
	//public PlayerController plr;
	 //remove these points - naother ways is better --- add a script that anges check points on player script 
	//public int currentPoint = 0;//current check point pos 
	//public Transform ressetPoint;//change the resset point baased on what happens//reset point scripts finds player and changes the resset point -- and try and reload level-> so move this ot level manager script in future 
	//public Transform []checkPoints = new Transform [3] ;//move this to anther script -- temporary  //make it a vector 3
	public Vector3 RespwanPoint;


	SpriteRenderer myImg;
	Color originalColor;



public AudioSource mySFX;
public AudioClip[] myAudioSounds = new AudioClip[2];


	void Start(){
		currentScene = FindObjectOfType<LevelManager>();//sets it to scene manager 
		health = PlayerPrefs.GetInt("PlayerHealth");;
		lives = PlayerPrefs.GetInt("PlayerLives");

		 Player  = GetComponent<Transform>();
		 anim = GetComponent<Animator>();
		RespwanPoint = gameObject.transform.position;

		myImg = GetComponent<SpriteRenderer>();
		originalColor = myImg.color;

		mySFX = GetComponent<AudioSource>();


			}


	void Update(){
		//Debug.Log("frame rate:"+ (1/Time.deltaTime));
		if(this.health<=0){
		resetVlues();
		}
//		Debug.Log("currunt point in array"+currentPoint);

	}

	void OnCollisionEnter2D(Collision2D coll){
//		Debug.Log("COLLIDER DMG");

		if(coll.gameObject.tag == "Dmg"){//refactor to a method - recive dmg and play anaimtaion 
				anim.Play("Dmg");
				this.health -=10; 
				Destroy(coll.gameObject);
			}

	}

	void OnTriggerEnter2D(Collider2D coll){
//	Debug.Log("TRIGGER DMG");
		if(coll.gameObject.tag == "InsDeath"){
			resetVlues();
	}

		if(coll.gameObject.tag == "Dmg"){
			//if something has this tag and it doesnt have a script attach it will send in basic dmg of 10hp
				GetDamageFromFire( 10);
			}

		if(coll.gameObject.tag =="CheckPoint"){

		RespwanPoint = coll.transform.position;
		}

	}
	/// <summary>
	/// this method is called whenever the player's health is lower than 0 
	///makes the player loose a life and resets valyues as the name implies 
	/// </summary>
	public void resetVlues(){

	if(lives>0){
		//StartCoroutine("waitAndPlayDeath");
		anim.Play("IDLE");
		//StartCoroutine("ResspawnPlayer");
			ResspawnPlayer();

		this.lives-=1;
		this.health =100;


	}
	else 
		currentScene.GameOver();
	}//else quit to menue 

	/// <summary>
	/// this method is used among scriprs that would deal their own damage formual and sends it here to reduce dmg and play anaimtion...etc from one script 
	/// </summary>
	/// <param name="dmg">Dmg.</param>
	public void GetDamageFromFire(int dmg){
			//print("player lost "+dmg+"hp points"); 
			this.health-=dmg;
			StartCoroutine("FlashPlayer");
			anim.Play("Dmg");
			if(!mySFX.isPlaying){
			mySFX.PlayOneShot(myAudioSounds[0]);}
		


	}

	public string ReturnHealthInString(){

	 
			return health.ToString();

	}




	//use this in another script to respawn the player - cant set it deactive here 
	public void  ResspawnPlayer(){
		gameObject.SetActive(false);
		Instantiate(particleexp, gameObject.transform.position, gameObject.transform.rotation);
		Invoke("setPlayerToActive",2f);

	}

	public void setPlayerToActive(){
		Player.transform.position = RespwanPoint;
		gameObject.SetActive(true);
		myImg.color = originalColor ;



	}





IEnumerator  FlashPlayer(){
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


}


//Debug.Log("player lost a life");
		//this will be moved to its own script later on ///might use a for loop to triverse depending on how many checkpoints we want -- check with team 
		//if(currentPoint==0){
		//	Player.transform.position = checkPoints[0].transform.position;
	//	//	Debug.Log("at pos 0");}
	//	else if(currentPoint==1){
//Player.transform.position = checkPoints[1].transform.position;}
//	}else
			//currentScene.GameOver();
	///will add somehting in scene manager idf lives is less than 0 move to game over screen
	///these lies are used to transfer the player an dmake sure there are no duplicate co[ies - might move this to scene manager - but i dont need 
//	// 
//		if(PlayerinstanceTest!=null){
//		GameObject.Destroy(gameObject);
//		}
//		 else {//instance == nill 
//		GameObject.DontDestroyOnLoad(gameObject);
//			PlayerinstanceTest = this;
//		
//	}
//