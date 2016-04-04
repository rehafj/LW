using UnityEngine;
using System.Collections;

public class ActualPatrollingEnemy : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWalled;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;



    //on the rigid body 2d, add a fixed angle so he doesn't rotate and a circle collider for reasons
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this is the magic that determines whether there is a wall in front of the patrolling enemy
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWalled);

        //this is to check if the enemy is on the edge, and will make it turn back
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWalled);

        //an empty child must be created called "wall check" and "edge check" in order for it to be used properly
        //this is basically the collider that Josh was talking about so that it goes off of walls and such
        //this wall check whould be moved so that it will collide with a wall
        //this edge check should be moved so that it will collide with the ground (left bottom corner)
        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        //this is the code that will simply make the enemy move, we need to add more magic to make it do a check
        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}

