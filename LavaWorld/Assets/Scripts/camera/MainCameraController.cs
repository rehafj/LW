using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    //Derrives from MonoBehavior

	// Use this for initialization
   //public Vector3 postionI; 
   //public Vector3 targetPos;
   public GameObject PlayerPosition;
   PlayerController playerdirection;
    //playerdirect lets the script access stuff from the player script.  Just a name
   public Vector3 targetlocation;
    // Vector 3 takes X,Y, and Z does not take rotation
   public float smoothing = 0;
   public float xVal, Yval;
    float xPosition, yPosition, zPosition;

    //Use this for initialization
   void Start()
    {
       PlayerPosition = GameObject.FindGameObjectWithTag("Player");
       playerdirection = PlayerPosition.GetComponent<PlayerController>();
       //PlayerPosition = PlayerPosition.GetComponent<GameObject>();

   }
   void FixedUpdate()
   {
  /*      targetlocation = new Vector3(PlayerPosition.transform.position.x, PlayerPosition.transform.position.y, transform.position.z);
        //So it can maintain its own Z value

        if (playerdirection.isFacingRight)
       {
           //transform.position 
            targetlocation = new Vector3(PlayerPosition.transform.position.x + xVal, PlayerPosition.transform.position.y + Yval, transform.position.z);
            //makes the player look like she is on the left side of the screen, moves the camera right
           transform.position = Vector3.Lerp(transform.position, targetlocation, smoothing * Time.deltaTime);
            //lerp takes two things by a fraction of third value
       }
       else if (!playerdirection.isFacingRight)
       {
			targetlocation = new Vector3(PlayerPosition.transform.position.x - xVal, PlayerPosition.transform.position.y+Yval, transform.position.z);
          transform.position = Vector3.Lerp(transform.position, targetlocation, smoothing * Time.deltaTime);
       }
       //this one is based on the player's direction and would change the camera
       */
         xPosition = PlayerPosition.transform.position.x;
         yPosition = PlayerPosition.transform.position.y;
         zPosition = transform.position.z;
        //var means that the value is undefined in that particular instance or that it can change
        //I defined these on a local scope b/c I didnt think we'd use it anywhere
         //transform.position 
         if (PlayerPosition.transform.position.x > 100 || PlayerPosition.transform.position.x < 0)
         {
             xPosition = targetlocation.x;
         }
         if (PlayerPosition.transform.position.y > 100 || PlayerPosition.transform.position.y < -100)
         {
             yPosition = targetlocation.y;
         }
         else { }
         targetlocation = new Vector3(xPosition, yPosition, zPosition);


         transform.position = Vector3.Lerp(transform.position, targetlocation, 10f * Time.deltaTime); 
        //based on defined values and is updated
   }
}

