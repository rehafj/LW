using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// this script is used to manage updated text feilds ( such as health and lives) // future will hold bars and graphic (if time) 
/// </summary>
public class UIUpdate : MonoBehaviour {

	// Use this for initialization
	public Text myhealthText;
	public Text timerText;
	public Text TimeingDown;
	GameObject myPlayer;
	PlayerStatus playerStatusScript;
	Timer levelCountDown;
	string healthText = "current health: ";
//	string TimerRemaing = "left";
	//static UIUpdate InstanceOfUI;

	//going to change this later 
	void Start () {

//myPlayer = GameObject.FindGameObjectWithTag("Player");
//playerStatusScript = myPlayer.GetComponent<PlayerStatus>();
		playerStatusScript= FindObjectOfType<PlayerStatus>();
		levelCountDown = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
		//healht playerStatusScript.health).ToString;
		//playerStatusScript
		myhealthText.text =healthText + playerStatusScript.health.ToString() +"\ncurrent lives:"+playerStatusScript.lives.ToString() ;
		if(levelCountDown!=null){
			timerText.text = "survive " + levelCountDown.timer.ToString("F2")+ "!!";
			if(Time.realtimeSinceStartup<10f)
				TimeingDown.text = (levelCountDown.timer - 50).ToString("F2");
			else				TimeingDown.enabled = false;

		}

		//myhealthText.text =	"current lives:"+playerStatusScript.lives.ToString() ;
	}
}
