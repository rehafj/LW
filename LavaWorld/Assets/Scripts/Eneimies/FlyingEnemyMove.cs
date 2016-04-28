using UnityEngine;
using System.Collections;

public class FlyingEnemyMove : MonoBehaviour
{
    public PlayerController thePlayer;
    public float moveSpeed;
    public float playerRange;
    public LayerMask playerLayer;
    public bool playerInrange;
    public Rigidbody2D rgd;
    public Animator anim;
    Vector3 InitalPostion;
   public RespawnerGameObj pos;
	public bool isFacingRight = false;

    // Use this for initialization
    void Start()
    {
        //finds the player controller to make sure there is a player
        thePlayer = FindObjectOfType<PlayerController>();
		rgd = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		InitalPostion = GetComponent<Transform>().position;
		pos = GetComponent<RespawnerGameObj>();
    }

    // Update is called once per frame
    void Update()
	{	
        //will only attack in range of player, as long as the player is on the player layer
        playerInrange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (playerInrange)
		{	anim.SetBool("Moving", true);
			if( transform.position.x > thePlayer.transform.position.x && isFacingRight){
				flipIt();
				}
			else if (transform.position.x < thePlayer.transform.position.x && !isFacingRight){
				flipIt();
			}

			


            //will move towards the player if player controller object is found
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

        } else if ( !playerInrange){
				anim.SetBool("Moving", false);

			gameObject.transform.position = InitalPostion;
        }

    }
    void OnDrawGizmoSelected()
    {
        //to see the radius of the enemy range. To get rid of the giant circle, click on the enemy this component is on
        //click on the Gizmos tab next to heirarchy
        //and uncheck the box with this script (FlyingEnemyMove)
        Gizmos.DrawSphere(transform.position, playerRange);
    }


	void flipIt()
	{
		isFacingRight = !isFacingRight;
		Vector3 myscale = transform.localScale; //just like saving temp var - remember? 
		myscale.x = myscale.x *-1;
		transform.localScale = myscale;
	}

	void flipItRight()
	{
		//isFacingRight = !isFacingRight;
		Vector3 myscale = transform.localScale; //just like saving temp var - remember? 
		myscale.x = myscale.x *1;
		transform.localScale = myscale;
	}
		

    //temporary fix - c if otgers need it just update it o respawner script but check again how it was used it before
//	void OnBecameInvisible(){
//
//		pos.ResetDefaultpostions();
//	}
}