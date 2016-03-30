using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// this script is used to manage updated text feilds ( such as health and lives) // future will hold bars and graphic (if time) 
/// </summary>
public class UIUpdate : MonoBehaviour {

	// Use this for initialization
	public Text myhealthText;
	GameObject myPlayer;
	PlayerStatus playerStatusScript;
	string healthText = "current health: ";
	static UIUpdate InstanceOfUI;

	//going to change this later 
	void Start () {

//
//		if(InstanceOfUI!=null){//it exsits - destory it dont create another o=instacnae //do bnot dupilcate game managers 
//		GameObject.Destroy(gameObject);
//		}
//		else {//instance == nill 
//		GameObject.DontDestroyOnLoad(gameObject);//do not destoyr teh current gameobject ( i..e scene instance) 
//			InstanceOfUI = this;}
//


myPlayer = GameObject.FindGameObjectWithTag("Player");
playerStatusScript = myPlayer.GetComponent<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		//healht playerStatusScript.health).ToString;

		myhealthText.text =healthText + playerStatusScript.health.ToString() +"\ncurrent lives:"+playerStatusScript.lives.ToString() ;

	}
}
