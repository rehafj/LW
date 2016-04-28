using UnityEngine;
using System.Collections;
/// <summary>
/// as the name sugests this limits the bonds to the bonds of the camera - currenly used in BH section 
///attached to objects that cant move outside selected camera bound :) 
/// </summary>
public class LimitToCamBounds : MonoBehaviour {
float minX;
float maxX;
	// Use this for initialization
	void Start () {
	setBounds();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(transform.position.x<minX){
		Vector3 temp = transform.position;
		temp.x = minX;
		transform.position = temp;}	
	if(transform.position.x> maxX){
		Vector3 temp = transform.position;
		temp.x = maxX;
		transform.position = temp;

	}
	
	}
	public void setBounds(){
		Vector3 screenBounds = new Vector3( Screen.width, Screen.height, 0);
		Vector3 bounds = Camera.main.ScreenToWorldPoint(screenBounds);
		//beter to get this by getting the lplayer sixe and then deviding stuff 
		minX = -bounds.x/1.2f;
		maxX = bounds.x/1.2f;

	}
}
