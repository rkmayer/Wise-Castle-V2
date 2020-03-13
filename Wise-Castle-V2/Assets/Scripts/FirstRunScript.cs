using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRunScript : MonoBehaviour
{
	public int firstRun = 0;
	
    void Start(){
		firstRun = PlayerPrefs.GetInt("firstRun", 0);
        if(firstRun == 0){
			//first time running the game
			Debug.Log("first run");
			//show intro(?)
			//ask player to select difficulty
			//explain how game works
			//remove first run flag
			PlayerPrefs.SetInt("firstRun", 1);
		}
    }
}
