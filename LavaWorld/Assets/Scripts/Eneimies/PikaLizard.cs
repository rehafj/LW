using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject impactEffect;
    public float rotationSpeed;
    public int damageToGive;
    private Rigidbody2D myRigidbody2D;
    public Transform launchPoint;
    public float playerRange;
    public float shotWait;
    private float shotCounter;
    public LavaEffects lava;
    public GameObject shootyFire;
    // Use this for initialization
    void Start()
    {
        //enemy will look for the player
        player = FindObjectOfType<PlayerController>();

        //time in between projectiles
        shotCounter = shotWait;

        myRigidbody2D = GetComponent<Rigidbody2D>();

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
        myRigidbody2D.velocity = new Vector2(speed, myRigidbody2D.velocity.y);
        myRigidbody2D.angularVelocity = rotationSpeed;

        //shows the range of enemy sight in the console, but not in game
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y));

        shotCounter -= Time.deltaTime;

        // for the two if statments below, the enemy will shoot the player in range, on the left or right, after a cooldown period
        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            Instantiate(shootyFire, launchPoint.position, launchPoint.rotation);
            shotCounter = shotWait;
        }

        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            Instantiate(shootyFire, launchPoint.position, launchPoint.rotation);
            shotCounter = shotWait;
        }
         
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //the projectile the enemy shoots will hurt the player
        if (other.name == "Player")
        {
            GetComponent(typeof(LavaEffects));
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}