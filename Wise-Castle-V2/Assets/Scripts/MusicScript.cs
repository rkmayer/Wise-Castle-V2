using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
	//play this music uninterrupted between non-game scenes of app
	public AudioSource mainBackgroundMusic;
	
	public void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		mainBackgroundMusic = GetComponent<AudioSource>();
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
}
