using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

public AudioSource mySFX;
public AudioClip[] myAudioSounds = new AudioClip[4];
public PlayerController player; 
public PlayerStatus playerEXP; 
public float downTimer=0;
 void Start(){
		player = FindObjectOfType<PlayerController>();
		mySFX = GetComponent<AudioSource>();


}

void FixedUpdate(){



	if(player!=null){

		if(Input.GetButtonDown("Jump") && player.isGrounded){

			mySFX.clip = myAudioSounds[1];
			if(!mySFX.isPlaying){
			mySFX.Play();}

		}

		if(player.FoundWater){

			
			if(player.isCharging){

					mySFX.clip = myAudioSounds[0];
					if(!mySFX.isPlaying){
							mySFX.Play();

						 }

			}
		

			}//END OF FOUND WATER PAY THINGS 

			}//end of player things 





			}//end of fixed update 






	}



//
//	//>1 will play 
//			if(Input.GetButtonDown("shoot") && downTimer>0){
//
//					mySFX.clip = myAudioSounds[3];
//					if(!mySFX.isPlaying){
//						mySFX.Play();
//						}
//				}
//
//		downTimer-=Time.deltaTime;
//		downTimer = player.coolDownTimer;
