using UnityEngine;
using System.Collections;

public class EnableScripts : MonoBehaviour {
MonoBehaviour [] scriptsAttched; 
int TimesVisble = 0;
	// Use this for initialization
	void Awake () {
	scriptsAttched = GetComponents<MonoBehaviour>();
	foreach (MonoBehaviour script in scriptsAttched){

	script.enabled = false;
	}
	}
	
	// Update is called once per frame

	void OnBecameVisible() {
		TimesVisble+=1;

		if(TimesVisble==1){//so it does not call it each frame - will slow it down NVM onbecameivisble works once triggred does not call evryframe
			EnableScriptsAttached();
			TimesVisble=2;
		
		}
		//print("in onbecame visbale ");


	}


	void OnBecameInvisible() {
		DisableScriptsattached();
	}

		
	


	void EnableScriptsAttached (){
	foreach (MonoBehaviour script in scriptsAttched){

	script.enabled = true;

	}
	}

	void DisableScriptsattached(){
			foreach (MonoBehaviour script in scriptsAttched){

	script.enabled = false;
			TimesVisble=0;

	}
	}
}
