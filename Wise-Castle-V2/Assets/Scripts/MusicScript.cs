/*
	Main BG Music Script
	Ryan Mayer
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
	
	public AudioSource confirmSound;
	public AudioSource cancelSound;
	
	//play this music uninterrupted between non-game scenes of app
	public AudioSource mainBackgroundMusic;
	
	public void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
	
	public void PlayBGMusic(){
		if(mainBackgroundMusic.isPlaying){
			return;
		}
		mainBackgroundMusic.Play();
	}
	
	public void StopBGMusic(){
		mainBackgroundMusic.Stop();
	}
	
	public void PlayConfirmSound(){
		confirmSound.Play();
	}
	
	public void PlayCancelSound(){
		cancelSound.Play();
	}
}
