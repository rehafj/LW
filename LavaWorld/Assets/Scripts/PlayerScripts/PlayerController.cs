using UnityEngine;
using System.Collections;
//note to self: must refactor if time and use raycast to ccheck for ground!!
/// <summary>
/// thiss cript handles any control actions towards the player (i.e. controller)
///it will dandle anyinput from the keyboard/joystick it is used with the input manager - to c the input manager names( as i used button an dnot key) all values are defined there
///go too edit - project settings - imput and you will c the actions there 
///the mapping to a ps4 is sent via slack 
/// </summary>
public class PlayerController : MonoBehaviour {

// its like creating a type of directions - and mydirection is the varible - syinh directions.idle im acsessing the 4th index 
public enum Directions {right, left, up, down, idle};
 Directions myDirection = Directions.idle;

 Rigidbody2D rgd; 
 Sprite imgPlayer;//add code to switch sprites
 //varibles used to alter movment and jump/propelsion 
// bool isGrounded = false;
 public float speed=10;
 public float jumpStr=500;
 public float propelStrength=10;

 public Transform HoseLocation;
 public Rigidbody2D Projectile;

 //var used for charing a bullet 
 public float chargeTime=0;
 float maxTime=5; 
 public Rigidbody2D chargedShot;
 public bool chargedShotReady = false;
 Rigidbody2D typeofprojectile ;


 //these are used to count down based on timer - once reaced resets and counts down 
 public float coolDownTimer=1;// the lower this is th more bullets on screen at a time 
 float DownTime =0;


Animator anim;
public bool isFacingRight;
public bool FoundWater = false; // will acsess this value from  teh water creaturething undine? if this is false the player cant propel nor shoot stuff!
float timer =0 ;//this might be used later  for a charge shot 
	// Use this for initialization
	void Start () {
		typeofprojectile =  Projectile;

		//Debug.Log(myDirection);
		rgd = GetComponent<Rigidbody2D>();
		rgd.isKinematic = false;
		HoseLocation = GetComponent<Transform>();
		anim = GetComponent<Animator>();
		isFacingRight= true;
		timer= Time.deltaTime;
	}
	

	void FixedUpdate () {
		MovePlayer();
		//if(isGrounded)
		if(rgd.velocity.y==0)//ground check this will change into its own method with casting to check for gound ( better than this ) this is basiclaly checking the y speed of my player( 0) means not up or falling 
		{
		JumpAction();
		if(FoundWater){
		ProppelPlayer();}
		}

		ShootingDirectionsSwitch();
		ChargeShot();

		//timer=0;
	}


	/// <summary>
	/// Moves the player based on axsis (left/ right) vertical is used fot directions and not jumping .
	///setting directions is called here but  implemented called in another method 
	/// </summary>
	void MovePlayer(){
		int playerSideways = (int) Input.GetAxisRaw("Horizontal");
		int playerVertical = (int) Input.GetAxisRaw("Vertical");//using this to shoot directions up and down - jumping is used by x vlaue or space
		//Debug.Log(playerSideways);
		setPlayerDirection( playerSideways, playerVertical );
	
		//takes out ridgid body - adds a velocity to it  - vector 2 takes 2 x and y pos ( y is set to -1-1 depending 
		rgd.velocity= new Vector2(playerSideways * speed, rgd.velocity.y);
		//or by playing with teh transform pos (ulternate method) 


		if(playerSideways>0 && !isFacingRight) //val is +1 and flase 
		flipPlayer();
		else if (playerSideways<0 && isFacingRight)
		flipPlayer();
		}
		//TODO 
		/// <summary>
		/// handles nnormal jumps 
		/// </summary>
	void JumpAction(){//corresponds to x value 
		//add a  check if the player os on ground 
		if(Input.GetButtonDown("Jump")){//Input.GetKeyDown(KeyCode.JoystickButton1)
		//Debug.Log("jump pressed");
		anim.Play("Jump");
		rgd.AddForce(new Vector2 (0, jumpStr));
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
			rgd.AddForce(new Vector2 (0, propelStrength));
			//print("prppled by pressing both buttons");
		}

	

	}
	/// <summary>
	/// Flips the player.
	/// </summary>
	void flipPlayer()
	{
		isFacingRight = !isFacingRight; //do the oppisate if false / set it to true 
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
			
			timer= timer+ Time.deltaTime;
			chargeTime+=Time.deltaTime;
			switch(myDirection){
			case  Directions.right : {
					anim.Play("shoot");
					//ShootPojectile(myDirection); 
					break;}
			case Directions.left:{
					//print("left");
					anim.Play("shoot");
					//ShootPojectile(myDirection); 
					break;}
			case Directions.up:{
					//ShootPojectile(myDirection); 
					//print("up");
					break;}
			case Directions.down:{
					anim.Play("propelJump");
					//print("down");
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

		if( FoundWater){//only shoot if water is avaible 
			Rigidbody2D clone;

		if(direction == Directions.right){

				//created a temp clone of the same type as my bullet 
				  clone = Instantiate(typeofprojectile, HoseLocation.position, HoseLocation.transform.rotation) as Rigidbody2D;//does the coping 
        	      clone.velocity = transform.TransformDirection(Vector3.right * 15);//makes it face appropriate direction and adds vel ( speed over time) 
        	      clone.AddForce(clone.transform.right * 10);//gives it that extra push ( force) 
        	      //note gravity scale is set to low on prefab - so it doesnt fire at angles / if needed we can play with it ( its pretty cool ) :D 

	} else if( direction == Directions.left){
				  clone = Instantiate(typeofprojectile, HoseLocation.position, transform.rotation) as Rigidbody2D;
        	      clone.velocity = transform.TransformDirection(-Vector3.right * 15);
        	      clone.AddForce(clone.transform.right * 10);
	}
	else if ( direction == Directions.up){

				clone = Instantiate(typeofprojectile, HoseLocation.position, transform.rotation) as Rigidbody2D;
        	      clone.velocity = transform.TransformDirection(Vector3.up * 15);
        	      clone.AddForce(clone.transform.right * 10);
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
	}
	}
	 void ChargeShot(){
	if(Input.GetButton("shoot") && chargeTime<= maxTime){
			Debug.Log("charging");
			chargeTime+=Time.deltaTime;
			if(chargeTime>= maxTime)
				ReleaseChargeShot( myDirection);

			//can remove below if not desired effect - it will reset the charge if player relsaes button ( has to charge again ) 
		} if( Input.GetButtonUp("shoot")){
			Debug.Log("button was released");
				chargeTime=0;

			}

	}

	 void ReleaseChargeShot (Directions direction){

		   Debug.Log("fired charge Shot");
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

