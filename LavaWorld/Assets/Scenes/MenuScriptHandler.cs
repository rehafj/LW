using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScriptHandler : MonoBehaviour {
	public Animator anim;
	LevelManager mylevelInstace;
	public Transform childTrans;
	// Use this for initialization
	void Start () {
		mylevelInstace = FindObjectOfType<LevelManager>();
		anim= GetComponentInChildren<Animator>();
		childTrans = GetComponentInChildren<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartTheGame(){
		if(mylevelInstace!=null)
			mylevelInstace.SetInitialThings();
		else 
		{
			Debug.LogError("An instance of level manager does now exsist - Resetiing values-will not change across levels");
			mylevelInstace.currentScene=0;
		PlayerPrefs.SetInt("PlayerLives", 3);
		PlayerPrefs.SetInt("PlayerHealth", 100);

		}
		StartCoroutine(WaitAndMove(2.0F));

	}
	public void LevelSelect(){}

	public void QuitTheGame(){
	Application.Quit();
		}


	IEnumerator WaitAndMove(float waitTime) {
		if(anim!=null){
			anim.Play("falls");
		}
        yield return new WaitForSeconds(1f);

		SceneManager.LoadScene(1);


    }


    public void PlayAgain(){
		SceneManager.LoadScene(0);

    }
}
