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

    //private bool notAtEdge;
  //  public Transform edgeCheck;

  ///move this to a genric script that plays animations - maybe if alopt 

    //on the rigid body 2d, add a fixed angle so he doesn't rotate and a circle collider for reasons
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this is the magic that determines whether there is a wall in front of the patrolling enemy
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWalled);
//        Debug.Log(hittingWall );

		if (hittingWall )//|| !notAtEdge
        {
           moveRight = !moveRight;
           } 
     

      //  }

        //this is the code that will simply make the enemy move, we need to add more magic to make it do a check
        if (moveRight == true)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if( moveRight ==false)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

	IEnumerator SetDirection(float waitTime) {
				moveRight = false;

        yield return new WaitForSeconds(waitTime);
      
    }

//    public void SetDirection(){
//		moveRight = !moveRight;
//	
//	}

}

