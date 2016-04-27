using UnityEngine;
using System.Collections;

public class PikaLizard : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject impactEffect;
    public float rotationSpeed;
    public int damageToGive;
    private Rigidbody2D myRigidbody2D;
    public Transform launchPoint;
    public float playerRange;
    public float shotWait =1;
    private float shotCounter;
   // public LavaEffects lava;
    public Rigidbody2D shootyFire;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        //enemy will look for the player
        player = FindObjectOfType<PlayerController>();

        //time in between projectiles
        shotCounter = shotWait;

        myRigidbody2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        //keeps position working for the enemy
        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
//        myRigidbody2D.velocity = new Vector2(0, myRigidbody2D.velocity.y);
//        myRigidbody2D.angularVelocity = rotationSpeed;
//
//        //shows the range of enemy sight in the console, but not in game
//        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y));
//
//        shotCounter -= Time.deltaTime;
//
//        // for the two if statments below, the enemy will shoot the player in range, on the left or right, after a cooldown period
//        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
//        {
//            Instantiate(shootyFire, launchPoint.position, launchPoint.rotation);
//            Debug.Log("intantaiton done");
//            shotCounter = shotWait;
//        }
//
//        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
//        {
//            Instantiate(shootyFire, launchPoint.position, launchPoint.rotation);
//            shotCounter = shotWait;
//        }
		       shotCounter -= Time.deltaTime;
//

if( transform.position.x> player.transform.position.x){
Debug.Log("Player is on te left");
Rigidbody2D temp =  Instantiate( shootyFire, transform.position, Quaternion.identity) as Rigidbody2D;
				temp.velocity =  transform.TransformDirection(Vector3.right * 15);
			shotCounter = shotWait;}
else {
			Debug.Log("Player is on te right");

			Rigidbody2D temp =  Instantiate( shootyFire, transform.position, Quaternion.identity) as Rigidbody2D;
			temp.velocity =  transform.TransformDirection(Vector3.right * 15); shotCounter = shotWait;

}

}
         
    
//
//    void OnTriggerEnter2D(Collider2D other)
//    {
//        //the projectile the enemy shoots will hurt the player
//        if (other.name == "Player")
//        {
//            GetComponent(typeof(LavaEffects));
//        }
//        Instantiate(impactEffect, transform.position, transform.rotation);
//        Destroy(gameObject);
//    }
}