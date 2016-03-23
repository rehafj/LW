using UnityEngine;
using System.Collections;

public class TestBullets : MonoBehaviour {
/// <summary>
/// this class is used to experamnt with diffrent bullet behaviors simply by rotating where it spawns from - simpler way to do things :D 
/// it has an initial count
/// </summary>
//public enum Directions {right, left, up, down, idle};
 //Directions myDirection = Directions.idle;

 Rigidbody2D rgd; 
public int rang_num = 15;
public Transform HoseLocation;
 public Rigidbody2D Projectile;
	public bool p1 = false, p2 = false, p3=false,p4=false, p5=false, p6=false;

 public int z = 0;

	// Use this for initialization
	void Start () {
		//Debug.Log(myDirection);
		Debug.Log("frame rate:"+ (1/Time.deltaTime));

		rgd = GetComponent<Rigidbody2D>();
		HoseLocation = GetComponent<Transform>();
	}

	void Update(){
		Debug.Log("frame rate:"+ (1/Time.deltaTime));

	}
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log("frame rate:"+ (1/Time.deltaTime));
	//	print("frame rate:"+ (1/Time.deltaTime));

	//Vector3 temp = new Vector3(1,2,1);
	//HoseLocation.rotation+= temp;
	//this can work with combo scripts and we can slow down instatination by making them under ienumabrle methods :D 
	if(p1){
	if( z< 180){
				//Debug.Log(z + " indide p1");
		Rigidbody2D clone;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,z);z++;
		clone = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
				clone.velocity = transform.TransformDirection(Vector3.right * rang_num);

        	// clone.AddForce(clone.transform.right * 10);//gives it that extra push ( force) 
	}}

	if(p2){//rotates at 90* angles over the z axses ( shows an x) if left at angle 45* initially 
			z=90;
		if( z< 180){
		//Debug.Log(z + " indide p2");
		Rigidbody2D clone;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,z);
		clone = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
				clone.velocity = transform.TransformDirection(Vector3.right * rang_num);

	}}
		//HoseLocation.Rotate(0,0,0);
		//this.HoseLocation.transform.position = new Vector3(0,0,0);

	
		if(p3){
			while( z< 180){//does this in burst cz its in a while loop
		Rigidbody2D clone;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,z);z++;
		//Debug.Log("indisde of p3 "+ z);

		clone = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
				clone.velocity = transform.TransformDirection(Vector3.right * rang_num);

	}}

		if(p6){
		z=0;
			while( z< 180){//does this in burst cz its in a while loop
		Rigidbody2D clone;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,z);z++;
		//Debug.Log("indisde of p3 "+ z);

		clone = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
				clone.velocity = transform.TransformDirection(Vector3.right * rang_num);

	}}

	//Debug.Log(z);
	//another one we can do rotate full (0-360 degrees) chage the z degree per rotation - 
		

	if(p4){
			z=0;
		if( z< 3608){
		Rigidbody2D clone;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,z);z++;
		clone = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
				clone.velocity = transform.TransformDirection(Vector3.right * rang_num);

	}}


		if(p5){
		int x=0;
	if( z< 180){
		Rigidbody2D clone;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,z);z++;
		clone = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
				clone.velocity = transform.TransformDirection(Vector3.right * rang_num);

	}
			Rigidbody2D fd;//created a temp clone of the same type as my bullet 
		HoseLocation.Rotate(0,0,x);z++;
		fd = Instantiate(Projectile, HoseLocation.position, HoseLocation.rotation) as Rigidbody2D;//does the coping 
			fd.velocity = transform.TransformDirection(Vector3.left * rang_num);

	}}


		/////
		/// note to self: i can have a paernt and have it move on x axsis while at the same time the buller moves the way it is itll look like a flower 
		///circules moving in all directions with the moving player 

	}





