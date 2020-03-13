/*
Difficulty - saves difficulty setting to get checked in each game

Ryan Mayer

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    /*
	Difficulties:
	easy, normal, hard
	easy = 0; normal = 1; hard = 2;
	*/
	
	public void DifficultySetEasy(){
		PlayerPrefs.SetInt("Difficulty", 0);
	}
	
	public void DifficultySetNormal(){
		PlayerPrefs.SetInt("Difficulty", 1);
	}
	
	public void DifficultySetHard(){
		PlayerPrefs.SetInt("Difficulty", 2);
	}
}
