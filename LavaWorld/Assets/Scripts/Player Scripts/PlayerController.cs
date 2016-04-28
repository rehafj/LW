using UnityEngine;
using System.Collections;
//note to self: must refactor if time  and clean up - 
/// <summary>
/// thiss cript handles any control actions towards the player (i.e. controller)
///shooting - jumping - directions - moving and special water things in terms of movment( propel) 
/// </summary>
public class PlayerController : MonoBehaviour {

														/*direction  and movement varibles*/
public enum Directions {right, left, up, down, idle};
 Directions myDirection = Directions.idle;

 public Rigidbody2D rgd; // so we can stop the cahrercter from hainv gnay veloctyu while moving - suddnly. ( why it is public) 
 public float speed=10;
 public float jumpStr=500;
 public float propelStrength=10;
 public bool isFacingRight;

public bool isGrounded = false;
 public  Transform groundChecker;
 public float checkRadius;
 public LayerMask groundMask;

													/*shooting / bullet varibles*/
 public Transform HoseLocation;
 public Rigidbody2D Projectile;
		Rigidbody2D typeofprojectile ;

														/*charge shot var */
   float chargeTime=0;//incrimints 
 public	float maxTime=5; 
 public Rigidbody2D chargedShot;
	bool chargedShotReady = false;
															/*recoil or wait time varibles*/
 public float coolDownTimer=1;								// the lower this is th more bullets on screen at a time 
 		float DownTime =0;


Animator anim;
public bool FoundWater = false; // will acsess this value from  teh water creaturething undine? if this is false the player cant propel nor shoot stuff!

public float knockbackforce=2;
	public float knockBackLastingFor=0.5f;
	 float knockcounterTimer;
	public bool cantGetHurt;


	public bool isCharging = false;//change this tos states o f enum if there is time 

//
//
//public AudioSource mySFX;
//public AudioClip[] myAudioSounds = new AudioClip[4];
//public PlayerStatus playerEXP;    /*own script*/
//

void Start () {
		typeofprojectile =  Projectile;
		rgd = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		isFacingRight= true;
	}
	


void FixedUpdate () {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, checkRadius, groundMask);
//        Debug.Log("AM I ON GROUND ? "+ isGrounded);
        if( knockcounterTimer<=0){
            MovePlayer();

            if(isGrounded)//rgd.velocity.y==0)//ground check this will change into its own method with casting to check for gound ( better than this ) this is basiclaly checking the y speed of my player( 0) means not up or falling 
            {
            //    Debug.Log("CAN JUMP");
                JumpAction();
                if(FoundWater){
                    ProppelPlayer();}
			}
			if(FoundWater){
            ShootingDirectionsSwitch();
            ChargeShot();}

            cantGetHurt = false;//When the timer ends the payer can get hurt

        }//end of knockback check
        if(knockcounterTimer>0){
                KnockThePlayerBack();
        }
        }
    

									/// <summary>
											/// Moves the player based on axsis (left/ right) vertical is used fot directions and not jumping .
											///setting directions is called here but  implemented called in another method 
											/// </summary>
	void MovePlayer(){
		int playerSideways = (int) Input.GetAxisRaw("Horizontal");
		int playerVertical = (int) Input.GetAxisRaw("Vertical");//using this to shoot directions up and down - jumping is used by x vlaue or space
		setPlayerDirection( playerSideways, playerVertical );
		rgd.velocity= new Vector2(playerSideways * speed, rgd.velocity.y);
																			//or by playing with teh transform pos (alternate method) 

		if(playerSideways>0 && !isFacingRight) //val is +1 and flase 
			flipPlayer();
		else if (playerSideways<0 && isFacingRight)
			flipPlayer();
		}



	void JumpAction(){//corresponds to x value 
		if(Input.GetButtonDown("Jump")){
			anim.Play("Jump");
			rgd.velocity = new Vector3(rgd.velocity.x, jumpStr, 0);
			//rgd.AddForce(new Vector2 (0, jumpStr));
			}
		}


												/// <summary>
												/// Sets the player direction/ for shoting later on 
												/// </summary>
												/// <param name="xDirecion">X  direcion.</param>
												/// <param name="yDirection">Y direction.</param>
	void setPlayerDirection(float xDirecion, float yDirection){
		if(xDirecion>0){
			myDirection = Directions.right;
		anim.SetBool("isRunning",true);}
		else if (xDirecion<0){
			myDirection = Directions.left;
			anim.SetBool("isRunning",true);}
		else if (yDirection>0) 
			myDirection = Directions.up;
		else if (yDirection <0)
			myDirection = Directions.down;
		else{
			myDirection = Directions.idle;
			anim.SetBool("isRunning",false);}
		}


													/// <summary>
													/// Proppels the player. upwards
													/// </summary>

	void ProppelPlayer(){
		if(myDirection==Directions.down &&(Input.GetButtonDown("shoot"))){
			//rgd.AddForce(new Vector2 (0, propelStrength));
			rgd.velocity = new Vector3(rgd.velocity.x, propelStrength, 0);

		}}

													/// <summary>
													/// Flips the player.
													/// </summary>
	void flipPlayer()
	{
		isFacingRight = !isFacingRight; 
		Vector3 myscale = transform.localScale; //just like saving temp var - remember? 
		myscale.x = myscale.x *-1;
		transform.localScale = myscale;
	}
													/// <summary>
													/// playing animation based on direction ( and sets up shooting //refavtor this 
													/// </summary>
	void ShootingDirectionsSwitch(){
	if(DownTime>0)
			DownTime -= Time.deltaTime;

		else if(Input.GetButtonDown("shoot")){
			chargeTime+=Time.deltaTime;
			switch(myDirection){
			case  Directions.right : {
					anim.Play("shoot");
					break;}
			case Directions.left:{
					anim.Play("shoot");
					break;}
			case Directions.up:{
					break;}
			case Directions.down:{
					anim.Play("propelJump");
					break;}

			default:{
		
					break;	}

							}
			ShootPojectile(myDirection); 

									}
			}

																/*
																int x(temp()  = myx 
																x(temp)= new thing you want it to be 
																myx = x(temp)*/

																/// <summary>
																/// actually shoots the projectile - this will not work unless the player got the water magical thing
																//this will be refactored onto the gun as a sperate script - if time 
																//added diff proj type 
																/// </summary>
																/// <param name="direction">takes in the Direction based on key type look up .</param>
																//TODO call it useing a pooler 1) 2) add a bullet bbehacior script to move the bullet based on player direciton 3) make it in its own method 
																//TODO refactor code so i dont create 4 colones and just send the value in s(same way i did a charge shot - cleaner) 

	public void ShootPojectile( Directions direction){


		setprojectileType();//set the projectile type 

	//	if( FoundWater){//only shoot if water is avaible 
			Rigidbody2D clone;

		if(direction == Directions.right){

				//created a temp clone of the same type/s as my bullet 
				  clone = Instantiate(typeofprojectile, HoseLocation.position, HoseLocation.transform.rotation) as Rigidbody2D;//does the coping 
        	      clone.velocity = transform.TransformDirection(Vector3.right * 15);//makes it face appropriate direction and adds vel ( speed over time) 
        	     // clone.AddForce(clone.transform.right * 10);//gives it that extra push ( force) 
        	      //note gravity scale is set to low on prefab - so it doesnt fire at angles / if needed we can play with it ( its pretty cool ) :D 

	} else if( direction == Directions.left){
				  clone = Instantiate(typeofprojectile, HoseLocation.position, transform.rotation) as Rigidbody2D;
        	      clone.velocity = transform.TransformDirection(-Vector3.right * 15);
        	     // clone.AddForce(clone.transform.right * 10);
	}
	else if ( direction == Directions.up){

				clone = Instantiate(typeofprojectile, HoseLocation.position, transform.rotation) as Rigidbody2D;
        	      clone.velocity = transform.TransformDirection(Vector3.up * 15);
        	      //clone.AddForce(clone.transform.right * 10);
	}

	else if(direction == Directions.idle){
				clone = Instantiate(typeofprojectile, HoseLocation.position, transform.rotation) as Rigidbody2D;

				if(isFacingRight)
				clone.velocity = transform.TransformDirection(Vector3.right* 15);
				else 
					clone.velocity = transform.TransformDirection(-Vector3.right* 15);

			}
			DownTime = coolDownTimer;
			chargedShotReady = false;
//	}
	}

																/// <summary>
																/// handles ccharing the bullet - to fire 
																/// </summary>
	 void ChargeShot(){
	if(Input.GetButton("shoot") && chargeTime<= maxTime){
		chargeTime+=Time.deltaTime;
			if(chargeTime>= (maxTime-2f)){
				anim.Play("charging");
				isCharging = true;}
			if(chargeTime>= maxTime)
				ReleaseChargeShot( myDirection);

		}
	 if( Input.GetButtonUp("shoot")){
//			Debug.Log("button was released");
			chargeTime=0;
			isCharging = false;
			//anim.SetBool("charging",false);
			}

	}

	 void ReleaseChargeShot (Directions direction){

		 //  Debug.Log("fired charge Shot");
			chargedShotReady = true;
		    ShootPojectile(myDirection);
			chargeTime=0;

	}


	void setprojectileType(){

	if (chargedShotReady==true){
			typeofprojectile = chargedShot;}

	else{
			typeofprojectile = Projectile;}
				}



	public void KnockBack(){
        //Debug.Log("knockedBakc");
    knockcounterTimer = knockBackLastingFor;
        cantGetHurt = true; //player cannot get hurt  
        //    rgd.velocity = new Vector3(-knockbackforce, 1, 0f);

    }

    void KnockThePlayerBack(){
        knockcounterTimer-= Time.deltaTime;//countdown till 0 
            if( isFacingRight){
                rgd.velocity = new Vector3(-(knockbackforce+2f), knockbackforce, 0f);}
            else {
			rgd.velocity = new Vector3(knockbackforce+2f, knockbackforce, 0f);}

            } 





		}//end of class 

//			alternate method and testing 
//		Vector2 tempX = rgd.velocity;
//		tempX.x = playerSideways * speed;
//		rgd.velocity = tempX;


//think og line cast to check if grouunded - better than comparing the players current velcoty on y 
//	void OnCollsionEnter2D ( Collider2D coll) {
//
//		if( coll.gameObject.tag == "Ground"){//if the raycasr is colliding with the ground 
//		print("emtred coll");
//			isGrounded = true;
//			}
//	}

