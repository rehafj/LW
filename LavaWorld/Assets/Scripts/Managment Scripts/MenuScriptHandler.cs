using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//rj-finalrdits 
/// <summary>
/// script to handle menu things 
/// </summary>
public class MenuScriptHandler : MonoBehaviour {

	public Animator anim;
	LevelManager mylevelInstace;
	public GameObject animatorSkull;
	AudioSource mySFX;
	//public Transform childTrans;
	// Use this for initialization
	void Start () {
		mylevelInstace = FindObjectOfType<LevelManager>();
		//anim= GetComponentInChildren<Animator>();
		animatorSkull = GameObject.FindGameObjectWithTag("AnimationMenu");
		if(animatorSkull!=null){
		anim = animatorSkull.GetComponent<Animator>();
		mySFX = GetComponent<AudioSource>();}
		//childTrans = GetComponentInChildren<Transform>();

	}
	

	public void StartTheGame(){

		if(mylevelInstace!=null)
			mylevelInstace.SetInitialThings();
		else 
		{
			Debug.LogError("An instance of level manager does now exsist - Resetiing values-will not change across levels");
			mylevelInstace.sceneCounter=0;
			PlayerPrefs.SetInt("PlayerLives", 3);
			PlayerPrefs.SetInt("PlayerHealth", 100);
			
		}
		StartCoroutine(WaitAndMove(3.0F));
	}

	public void startTheGameHardMode()

	{
		if(mylevelInstace!=null)
			mylevelInstace.isHardMode = true;
		StartTheGame();
	}

	public void startTheGameEasyMode()

	{
		if(mylevelInstace!=null)
			mylevelInstace.isHardMode = false;
		StartTheGame();
	}


	public void InstructionsMenu(){

		SceneManager.LoadScene(6);

	}

	public void QuitTheGame(){

		Application.Quit();

		}


	IEnumerator WaitAndMove(float waitTime) {

		//if(anim!=null){
		if(animatorSkull!=null){
			anim.Play("falls");
		}
		if(mySFX!=null){
		mySFX.Play();
		}
		yield return new WaitForSeconds(waitTime);

		SceneManager.LoadScene(1);
    }


    public void PlayAgain(){

		mylevelInstace.sceneCounter= 0;
		SceneManager.LoadScene(0);

    }
}
