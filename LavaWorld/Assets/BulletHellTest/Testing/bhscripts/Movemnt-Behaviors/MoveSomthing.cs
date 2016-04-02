using UnityEngine;
using System.Collections;

public class MoveSomthing : MonoBehaviour {
float timer = 0;
public int width = 3, height = 4;
public GameObject target;
public Vector3 distanceBetween;
public float speed =1f;
public Vector3 offset;
Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
	target = GameObject.FindGameObjectWithTag("Player");
		offset.y = (transform.position.y - target.transform.position.y)/2;//get half the distance 
		rgb = GetComponent<Rigidbody2D>();
	}
	/// <summary>
	/// calculate distance in a baetter way
	/// </summary>
	// Update is called once per frame
	void Update () {
	//	rgb.velocity = new Vector2(0,-1) * speed;//move it down 
		//calcualte teh distance 
	//	float distance = Vector3.Distance(transform.position, target.transform.position);
		//if it is less than half te h distance activate round movment 
	//	if(distance<=offset.y){
			Debug.Log("distance is close to player");
			timer += Time.deltaTime;
			float xpos = Mathf.Cos(timer)* width;
			float ypos = Mathf.Sin(timer)* height;
			transform.position = new Vector3(xpos,ypos, 0);
		}
			}
//}
