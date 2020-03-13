/*
Difficulty - saves difficulty setting to get checked in each game

Ryan Mayer

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    /*
	Difficulties:
	easy, normal, hard
	easy = 0; normal = 1; hard = 2;
	*/
	
	[SerializeField] Button easyBtn, normalBtn, hardBtn;
	
	public void Start(){
		
	}
	
	public void DifficultySetEasy(){
		PlayerPrefs.SetInt("Difficulty", 0);
		easyBtn.interactable = false;
		normalBtn.interactable = true;
		hardBtn.interactable = true;
	}
	
	public void DifficultySetNormal(){
		PlayerPrefs.SetInt("Difficulty", 1);
		easyBtn.interactable = true;
		normalBtn.interactable = false;
		hardBtn.interactable = true;
	}
	
	public void DifficultySetHard(){
		PlayerPrefs.SetInt("Difficulty", 2);
		easyBtn.interactable = true;
		normalBtn.interactable = true;
		hardBtn.interactable = false;
	}
}
