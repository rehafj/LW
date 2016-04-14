using UnityEngine;
using System.Collections;

public class ObjectSwitch : MonoBehaviour {
	public Sprite mysprite;
	public Sprite initialSprite;
	public Sprite platform; 
	//public GameObject initialGameObject; 
	//public GameObject switchedObject; 
	//public GameObject OriginalHolder; 
	public LavaEffects current;
	public int tempHealth;
	Rigidbody2D rgd;

	BoxCollider2D colliderEdges;
	public Vector3 Oldmyscale;
	public Vector3 newScaled;

	public Animator anim;
	public  float waitTime=8;
	// Use this for initialization
	void Start () {
	mysprite = gameObject.GetComponent<SpriteRenderer>().sprite;
	rgd = GetComponent<Rigidbody2D>();
	initialSprite = mysprite;
	mysprite = platform;
	//initialGameObject =gameObject;
	//OriginalHolder = initialGameObject;
	current = gameObject.GetComponent<LavaEffects>();
	tempHealth = current.HitsToDestroy;
	current.enabled = true;
	//Oldmyscale = gameObject.transform.localScale;

	colliderEdges = GetComponent<BoxCollider2D>();

	anim = GetComponent<Animator>();
	anim.SetBool("moving",true);
//		myscale.x = colliderEdges.size.x;
//		myscale.y = colliderEdges.size.y;
//
//		platform.border.Set (myscale.x, myscale.y, myscale.z,0);

	//OriginalHolder =initialGameObject;
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Water")	{
			Debug.Log("hitviawater");
			if ( current.HitsToDestroy < (tempHealth)){

				StartCoroutine("changeGameObject",waitTime);
								current.HitsToDestroy = tempHealth;
			}


			}
			}


	IEnumerator changeGameObject(float waitTime) {
        //anim.SetBool("moving",false);
        anim.enabled = false;
        ///ask about htis - does not recive it unles i get componenet but doing it this way is too taxting ?
        gameObject.GetComponent<SpriteRenderer>().sprite = platform;
		//mysprite = platform;
		gameObject.transform.localScale = Oldmyscale;
		//current.enabled = false;  disables it but not its funtionality ... 
		current.howMuchDamage = 0;
		rgd.constraints = RigidbodyConstraints2D.FreezeAll;
		colliderEdges.size = platform.bounds.size;
		yield return new WaitForSeconds(waitTime);

		anim.enabled = true;

		colliderEdges.size = initialSprite.bounds.size;
		mysprite= initialSprite;
		//current.enabled = false;
		current.howMuchDamage = 10;
		rgd.constraints = RigidbodyConstraints2D.None;
		rgd.constraints = RigidbodyConstraints2D.FreezeRotation;
		gameObject.GetComponent<SpriteRenderer>().sprite = initialSprite;




    }


}
