using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour
{
    public float targetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform target;
    Rigidbody2D theRigidBody;
    Renderer myRender;
    // Use this for initialization
    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetDistance = Vector2.Distance(target.position, transform.position);
        if (targetDistance < enemyLookDistance)
        {
            lookAtPlayer();
        }
        if (targetDistance < attackDistance)
        {
            attackPlease();
        }


    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
    void attackPlease()
    {
        theRigidBody.AddForce(transform.forward * enemyMovementSpeed);
    }
}
