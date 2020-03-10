/*
	Math Game Script
	Ryan Mayer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathGameScript : MonoBehaviour
{
	//game variables
	//the player speed
	public float playerSpeed = 150;
	[SerializeField] private Animator myAnimationController;
	
	//bool to check if player is stopped
	public bool stopped = false;
	
	//audio
	public AudioSource questionCompleteSound;
	public AudioSource incorrectSound;
	public AudioSource enterSound;
	public AudioSource bgMusic;
	public AudioSource levelCompleteSound;
	
	//points
	public int pointsEarned = 0;
	public int questionsRemaining = 3;
	
	//collision
	public Collider2D objectTouching;
	
	//ui
	public GameObject ui;
	public CanvasGroup ui_group;
	
	public GameObject finish_ui;
	public CanvasGroup finish_group;
	public Text pointsText;
	
	public Text questionText;
	public Text inputText;
	
	//buttons
	public Button button_0, button_1, button_2, button_3, button_4, button_5,
	button_6, button_7, button_8, button_9, button_plus, button_minus,
	button_divide, button_multiply, button_enter, button_OK, button_back;
	
	//components of math question
	int num1;
	int num2;
	char math_operator;
	int answer;
	int blockToEnter; //0 = 1st num, 1 = 2nd num, 2 = operator, 3 = answer is blank
	int operatorUsed; //0 = +, 1 = -, 2 = /, 3 = x
	
	void Start(){
		//pause main bg music
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().StopBGMusic();
		
		//get the math UI - this (player) -> child (camera) -> child (UI)
		ui = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
		ui_group = ui.GetComponent<CanvasGroup>();
		//start game with math ui hidden
		hideUI();
		
		//get finish UI
		finish_ui = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
		finish_group = finish_ui.GetComponent<CanvasGroup>();
		//start game with finish ui hidden
		hideFinishUI();
		
		//add listeners to all buttons
		button_0.onClick.AddListener(() => inputValue('0'));
		button_1.onClick.AddListener(() => inputValue('1'));
		button_2.onClick.AddListener(() => inputValue('2'));
		button_3.onClick.AddListener(() => inputValue('3'));
		button_4.onClick.AddListener(() => inputValue('4'));
		button_5.onClick.AddListener(() => inputValue('5'));
		button_6.onClick.AddListener(() => inputValue('6'));
		button_7.onClick.AddListener(() => inputValue('7'));
		button_8.onClick.AddListener(() => inputValue('8'));
		button_9.onClick.AddListener(() => inputValue('9'));
		button_plus.onClick.AddListener(() => inputValue('+'));
		button_minus.onClick.AddListener(() => inputValue('-'));
		button_divide.onClick.AddListener(() => inputValue((char)247));
		button_multiply.onClick.AddListener(() => inputValue('x'));
		
		button_enter.onClick.AddListener(enterInput);
		
		button_OK.onClick.AddListener(goBackToMain);
		
		button_back.onClick.AddListener(deleteInput);
		
		//play background music
		bgMusic.Play();
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
		objectTouching = other;
		myAnimationController.SetBool("tail", true);
		//stop player
		stopped = true;
		//show math question
		showUI();
		generateQuestion();
	}
	
	//question was answered correctly
	public void pass(){
		//award points
		pointsEarned = pointsEarned + 5;
		//delete object
		if(objectTouching.gameObject.tag == "delete"){
			Destroy(objectTouching.gameObject);
			stopped = false;
			myAnimationController.SetBool("tail", false);
		}
		//clear and hide UI
		inputText.text = "";
		hideUI();
		//decrement questions
		questionsRemaining--;
		if(questionsRemaining == 0){
			//all questions answered... 
			myAnimationController.SetBool("tail", true);
			//show finish ui and return to main scene (button)
			showFinishUI();
			//stop background music
			bgMusic.Stop();
			levelCompleteSound.Play();
			//stop player
			stopped = true;
		}else{
			//play complete sound
			questionCompleteSound.Play();
		}
	}
	
	//show the question UI
	public void showUI(){
		//set alpha to opaque and allow interactions
		ui_group.alpha = 1f;
		ui_group.blocksRaycasts = true;
	}
	
	//hide the question UI
	public void hideUI(){
		//set alpha to transparent and do not allow interactions
		ui_group.alpha = 0f;
		ui_group.blocksRaycasts = false;
	}
	
	//show the finish UI
	public void showFinishUI(){
		//set alpha to opaque and allow interactions
		finish_group.alpha = 1f;
		finish_group.blocksRaycasts = true;
		pointsText.text = pointsEarned.ToString();
	}
	
	//hide the finish UI
	public void hideFinishUI(){
		//set alpha to transparent and do not allow interactions
		finish_group.alpha = 0f;
		finish_group.blocksRaycasts = false;
	}
	
	//factor function
	public int getFactor(int x){
		List<int> factors = new List<int>();
		for(int i = 1; i < x; i++){
			if( (x % i) == 0){
				//i is a factor of x
				factors.Add(i);
			}	
		}
		int random_factor = Random.Range(0, factors.Count);
		if(factors[random_factor] != 0){
			return factors[random_factor];
		}else{
			return 1;
		}
	}
	
	//generate question
	public void generateQuestion(){
		//randomly assign one block to be blank
		blockToEnter = Random.Range(0,4);
		
		//randomly choose an operator
		operatorUsed = Random.Range(0,4);
		
		//generate question...
		if(blockToEnter == 0){
			//...with 1st number blank
			num2 = Random.Range(1,13);
			switch(operatorUsed){
				case(0):
				//addition
				math_operator = '+';
				num1 = Random.Range(1,13);
				answer = num1 + num2;
				questionText.text = "? " + math_operator + " " + num2 + " = " + answer;
				break;
				case(1):
				//subtraction
				math_operator = '-';
				num1 = Random.Range(num2, num2*2);
				answer = num1 - num2;
				questionText.text = "? " + math_operator + " " + num2 + " = " + answer;
				break;
				case(2):
				//division
				math_operator = (char)247;
				num1 = Random.Range(2,25);
				num2 = getFactor(num1);	
				answer = num1 / num2;
				questionText.text = "? " + math_operator + " " + num2 + " = " + answer;
				break;
				case(3):
				//multiplication
				math_operator = 'x';
				num1 = Random.Range(0, 13);
				answer = num1 * num2;
				questionText.text = "? " + math_operator + " " + num2 + " = " + answer;
				break;
			}
		}else if(blockToEnter == 1){
			//...with 2nd number blank
			num1 = Random.Range(2,13);
			switch(operatorUsed){
				case(0):
				//addition
				math_operator = '+';
				num2 = Random.Range(0,13);
				answer = num1 + num2;
				questionText.text = num1 + " " + math_operator + " ?" + " = " + answer;
				break;
				case(1):
				//subtraction
				math_operator = '-';
				num2 = Random.Range(0, num1+1);
				answer = num1 - num2;
				questionText.text = num1 + " " + math_operator + " ?" + " = " + answer;
				break;
				case(2):
				//division
				math_operator = (char)247;
				num2 = getFactor(num1);
				answer = num1 / num2;
				questionText.text = num1 + " " + math_operator + " ?" + " = " + answer;
				break;
				case(3):
				//multiplication
				math_operator = 'x';
				num2 = Random.Range(0, 13);
				answer = num1 * num2;
				questionText.text = num1 + " " + math_operator + " ?" + " = " + answer;
				break;
			}
		}else if(blockToEnter == 2){
			//...with operator blank
			num1 = Random.Range(2, 13);
			switch(operatorUsed){
				case(0):
				//addition
				math_operator = '+';
				num2 = Random.Range(0,13);
				answer = num1 + num2;
				questionText.text = num1 + " ? " + num2 + " = " + answer;
				break;
				case(1):
				//subtraction
				math_operator = '-';
				num2 = Random.Range(0, num1+1);
				answer = num1 - num2;
				questionText.text = num1 + " ? " + num2 + " = " + answer;
				break;
				case(2):
				//division
				math_operator = (char)247;
				num2 = getFactor(num1);
				answer = num1 / num2;
				questionText.text = num1 + " ? " + num2 + " = " + answer;
				break;
				case(3):
				//multiplication
				math_operator = 'x';
				num2 = Random.Range(0, 13);
				answer = num1 * num2;
				questionText.text = num1 + " ? " + num2 + " = " + answer;
				break;
			}
		}else{
			//...with answer blank
			num1 = Random.Range(2, 13);
			switch(operatorUsed){
				case(0):
				//addition
				math_operator = '+';
				num2 = Random.Range(0,13);
				answer = num1 + num2;
				questionText.text = num1 + " " + math_operator + " " + num2 + " = ?";
				break;
				case(1):
				//subtraction
				math_operator = '-';
				num2 = Random.Range(0, num1+1);
				answer = num1 - num2;
				questionText.text = num1 + " " + math_operator + " " + num2 + " = ?";
				break;
				case(2):
				//division
				math_operator = (char)247;
				num2 = getFactor(num1);
				answer = num1 / num2;
				questionText.text = num1 + " " + math_operator + " " + num2 + " = ?";
				break;
				case(3):
				//multiplication
				math_operator = 'x';
				num2 = Random.Range(0, 13);
				answer = num1 * num2;
				questionText.text = num1 + " " + math_operator + " " + num2 + " = ?";
				break;
			}
		}
	}
	
	//input
	public void inputValue(char val){
		enterSound.Play();
		inputText.text = inputText.text + val;
	}
	
	//backspace
	public void deleteInput(){
		enterSound.Play();
		inputText.text = "";
	}
	
	public void enterInput(){
		
		//find which block is blank
		switch(blockToEnter){
			case(0):
			//1st num is blank
			//check is input is correct
			if(num1 == int.Parse(inputText.text)){
				//is correct
				pass();
			}else{
				//is incorrect
				inputText.text = "";
				incorrectSound.Play();
			}
			break;
			case(1):
			//2nd num is blank
			if(num2 == int.Parse(inputText.text)){
				//is correct
				pass();
			}else{
				//is incorrect
				inputText.text = "";
				incorrectSound.Play();
			}
			break;
			case(2):
			//operator is blank
			char operatorEntered = char.Parse(inputText.text);
			if(evalOperator(operatorEntered)){
				//is correct
				pass();
			}else{
				//is incorrect
				inputText.text = "";
				incorrectSound.Play();
			}
			break;
			case(3):
			//answer is blank
			if(answer == int.Parse(inputText.text)){
				//is correct
				pass();
			}else{
				//is incorrect
				inputText.text = "";
				incorrectSound.Play();
			}
			break;
		}
	}
	
	//evaluates the equation - allows multiple answers for one question if any
	public bool evalOperator(char x){
		bool passed = false;
		
		switch(x){
			case('+'):
			if(num1 + num2 == answer){
				passed = true;
			}
			break;
			case('-'):
			if(num1 - num2 == answer){
				passed = true;
			}
			break;
			case((char)247):
			if(num1 / num2 == answer){
				passed = true;
			}
			break;
			case('x'):
			if(num1 * num2 == answer){
				passed = true;
			}
			break;
		}
		
		return passed;
		
	}
	
	//go back to main scene
	public void goBackToMain(){
		enterSound.Play();
		//play main bg music
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayBGMusic();
		//save points
		GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>().AddPoints(pointsEarned);
		SceneManager.LoadScene("main");
	}
}
