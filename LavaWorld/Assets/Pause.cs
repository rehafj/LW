using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
bool ispauses = false;
bool showGui = false;
public GUITexture mytext;	// Use this for initialization
	void Start () {
		mytext=	gameObject.GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("p")){

		ispauses = !ispauses;
		if( ispauses == true){
		Time.timeScale = 0;
			ispauses = true;
			showGui = true;
		}
		if( ispauses == false){
		Time.timeScale = 1;
			ispauses = false;
			showGui = false;

		}

		if( showGui ==true){
		mytext.enabled = true;
		} else		mytext.enabled = false;


	}
	}
}
