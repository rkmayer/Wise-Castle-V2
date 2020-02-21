using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGameScript : MonoBehaviour
{
	
	public float playerSpeed = 150;
	
	public bool stopped = false;
	
	public bool questionPassed = false;
	
	public GameObject ui;
	public CanvasGroup ui_group;
	
	public Text questionText;
	
	void Start(){
		//get the UI - this (player) -> child (camera) -> child (UI)
		ui = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
		ui_group = ui.GetComponent<CanvasGroup>();
		//start game with ui hidden
		hideUI();
	}
	
    // Update is called once per frame
    void Update(){
		//unless player is stopped (by object)...
		if(!stopped){
			//...player moves right automatically
			transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
		}
        
    }
	
	//player collides with object
	public void OnTriggerEnter2D(Collider2D other){
		//stop player
		stopped = true;
		//show math question
		showUI();
		generateQuestion();
		//after question is passed...
		if(questionPassed){
			//award points(?)
			//delete object
			if(other.gameObject.tag == "delete"){
				Destroy(other.gameObject);
				stopped = false;
			}
		}
	}
	
	public void showUI(){
		//set alpha to opaque and allow interactions
		ui_group.alpha = 1f;
		ui_group.blocksRaycasts = true;
	}
	
	public void hideUI(){
		//set alpha to transparent and do not allow interactions
		ui_group.alpha = 0f;
		ui_group.blocksRaycasts = false;
	}
	
	public void generateQuestion(){
		//components of math question
		int num1;
		int num2;
		char math_operator;
		int answer;
		
		//randomly assign one block to be blank
		int blockToEnter = Random.Range(0,4);
		
		//generate question...
		if(blockToEnter == 0){
			//...with 1st number blank
			questionText.text = "Hello There 0";
		}else if(blockToEnter == 1){
			//...with 2nd number blank
			questionText.text = "Hello There 1";
		}else if(blockToEnter == 2){
			//...with operator blank
			questionText.text = "Hello There 2";
		}else{
			//...with answer blank
			questionText.text = "Hello There 3";
		}
		
	}
}
