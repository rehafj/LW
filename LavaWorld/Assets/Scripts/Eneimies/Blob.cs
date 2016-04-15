using UnityEngine;
using System.Collections;

public class Blob : MonoBehaviour {

	// Use this for initialization
	public	Transform startPos;
	public Transform endPos; 
	Rigidbody2D rgd;
	public float waitTimr =5f;
	public float speed=1f;
	public bool movingtowardEnd;
	Vector2 initialSize;
	BoxCollider2D mycol;
	public float expandedColliderSize = 1.5f;
	public bool canMove;
	LavaEffects ThisEnemiesVulnrability;
	 Animator anim;

	public float forceY =0;
	void Start () {

	rgd = GetComponent<Rigidbody2D>();
	mycol = GetComponent<BoxCollider2D>();
	initialSize = mycol.size; //save the current colider size 
	ThisEnemiesVulnrability = GetComponent<LavaEffects>();
	anim = GetComponent<Animator>();
		//anim.Play("BlOBattac");

	}
	
	// Update is called once per frame
	void Update () {
		checkMovments();
		expandCollider();
		//waitTimr-=Time.deltaTime;
		StartCoroutine(WaitAndMove(waitTimr));

	if(canMove){
			
		//	anim.SetBool("attack",false);

		if(movingtowardEnd){
				rgd.velocity = new Vector3(speed , rgd.velocity.y, 0f);

		} 
		else if ( !movingtowardEnd){
			rgd.velocity = new Vector3(-speed ,rgd.velocity.y , 0f);
			}
			//anim.SetBool("attack",false);

			//anim.SetBool("attack",true);

			}
	}


	void checkMovments(){ 

		if(movingtowardEnd && transform.position.x>  endPos.position.x){
			movingtowardEnd = false;}
	if(!movingtowardEnd && transform.position.x <  startPos.position.x){
			movingtowardEnd = true;}}


	void expandCollider(){
		if(!canMove)
		mycol.size = new Vector2(  expandedColliderSize, mycol.size.y);
		else 
			mycol.size = initialSize;
	}


	IEnumerator WaitAndMove(float waitTime) {
		//canMove = false;
		if( canMove == true){
//			Debug.Log("setting to false");
			yield return new WaitForSeconds(waitTime);
			canMove = false;
			//anim.Play("BlOBattac");
			//anim.Stop("BlOBattac");
			anim.SetBool("attack",true);
			ThisEnemiesVulnrability.CannotGetHit = true;
			rgd.AddForce(new Vector2(0, forceY));
		}
		else if(!canMove){
			//anim.SetBool("attack",false);

			yield return new WaitForSeconds(waitTime);
			canMove = true;
			anim.SetBool("attack",false);
			ThisEnemiesVulnrability.CannotGetHit = false;
		//	Debug.Log("setting to true");

			}


		//canMove = true;

    }

//	}
}
//
//		transform.position = Vector3.MoveTowards(transform.position, startPos.position,Time.deltaTime * speed);

//	
