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

    // Use this for initialization
    void Start()
    {
        //finds the player controller to make sure there is a player
        thePlayer = FindObjectOfType<PlayerController>();
		rgd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //will only attack in range of player, as long as the player is on the player layer
        playerInrange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (playerInrange)
        {rgd.isKinematic = false;
            //will move towards the player if player controller object is found
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

        } else if ( !playerInrange){
			rgd.isKinematic = true;
        }

    }
    void OnDrawGizmoSelected()
    {
        //to see the radius of the enemy range. To get rid of the giant circle, click on the enemy this component is on
        //click on the Gizmos tab next to heirarchy
        //and uncheck the box with this script (FlyingEnemyMove)
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}