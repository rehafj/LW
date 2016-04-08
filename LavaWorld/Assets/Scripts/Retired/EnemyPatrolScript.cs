using UnityEngine;
using System.Collections;

public class EnemyPatrolScript : MonoBehaviour
{

    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D enemyBody;
    Transform enemyTransform;
    float enemyWidth;
    float enemyHeight;



    // Use this for initialization
    void Start()
    {
        enemyTransform = this.transform;
        enemyBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer enemySprite = this.GetComponent<SpriteRenderer>();
        enemyWidth = enemySprite.bounds.extents.x;
        enemyHeight = enemySprite.bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // check: is there something blocking us from moving forward?
        Vector2 lineCastPosition = enemyTransform.position - enemyTransform.right * enemyWidth;
        bool isGrounded = Physics2D.Linecast(lineCastPosition, lineCastPosition + Vector2.down, enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPosition, lineCastPosition - Vector2.down, enemyMask);
        //always move forward
        Vector2 enemyVelocity = enemyBody.velocity;
        enemyVelocity.x = -enemyTransform.right.x * speed;
        enemyBody.velocity = enemyVelocity;

        //no ground? Turn Around!

        if (!isGrounded || isBlocked)
        {
            Vector3 currentRotation = enemyTransform.eulerAngles;
            currentRotation.y += 180;
            enemyTransform.eulerAngles = currentRotation;
            // in order for rotation to work, enemy mask must be set to everything EXCEPT enemy. The enmy sprite must also be on the enemy layer in the inspector
        }
    }
}
