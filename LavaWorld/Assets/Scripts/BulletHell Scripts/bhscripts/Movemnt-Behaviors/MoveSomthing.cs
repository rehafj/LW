using UnityEngine;
using System.Collections;
/// <summary>
/// 5 am naming - this just moves it in a cir pattern 
/// </summary>
public class MoveSomthing : MonoBehaviour {
float timer = 0;
public int width = 3, height = 4;
public GameObject target;
public Vector3 distanceBetween;
public float speed =1f;
//public Vector3 offset;
//Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
	target = GameObject.FindGameObjectWithTag("Player");
		//offset.y = (transform.position.y - target.transform.position.y)/2;//get half the distance 
		//rgb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {

			timer += Time.deltaTime;
			float xpos = Mathf.Cos(timer)* width;
			float ypos = Mathf.Sin(timer)* height;
			transform.position = new Vector3(xpos,ypos, 0);
			if(target!=null){
			//transform.Rotate(0f,0f,target.transform.position.z);
			//transform.position = Vector3.Lerp(transform.position, target.transform.position, 0f);

			//transform.LookAt(Vector3(target.transform.position.x , target.transform.position.y ,0f)); 
			}
		}
			}
//}
