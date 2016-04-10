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
            //will move towards the player if player controller object is found
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

        } else if ( !playerInrange){
				anim.SetBool("Moving", true);

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

    //temporary fix - c if otgers need it just update it o respawner script but check again how it was used it before
//	void OnBecameInvisible(){
//
//		pos.ResetDefaultpostions();
//	}
}