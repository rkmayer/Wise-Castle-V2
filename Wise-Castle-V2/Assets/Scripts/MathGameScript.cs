using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathGameScript : MonoBehaviour
{
	public float playerSpeed = 150;
	
	public bool stopped = false;
	
	public int pointsEarned = 0;
	public int questionsRemaining = 3;
	
	public Collider2D objectTouching;
	
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
	button_divide, button_multiply, button_enter, button_OK;
	
	//components of math question
	int num1;
	int num2;
	char math_operator;
	int answer;
	int blockToEnter; //0 = 1st num, 1 = 2nd num, 2 = operator, 3 = answer is blank
	int operatorUsed; //0 = +, 1 = -, 2 = /, 3 = x
	
	void Start(){
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
		button_divide.onClick.AddListener(() => inputValue('/'));
		button_multiply.onClick.AddListener(() => inputValue('x'));
		
		button_enter.onClick.AddListener(enterInput);
		
		button_OK.onClick.AddListener(goBackToMain);
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
		//stop player
		stopped = true;
		//show math question
		showUI();
		generateQuestion();
	}
	
	//question was answered correctly
	public void pass(){
		//award points
		pointsEarned = pointsEarned + 10;
		//delete object
		if(objectTouching.gameObject.tag == "delete"){
			Destroy(objectTouching.gameObject);
			stopped = false;
		}
		//clear and hide UI
		inputText.text = "";
		hideUI();
		//decrement questions
		questionsRemaining--;
		if(questionsRemaining == 0){
			//all questions answered... show finish ui and return to main scene (button)
			showFinishUI();
			//stop player
			stopped = true;
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
	
	//generate question
	public void generateQuestion(){
		//randomly assign one block to be blank
		blockToEnter = Random.Range(0,4);
		
		//randomly choose an operator
		operatorUsed = Random.Range(0,4);
		
		//generate question...
		if(blockToEnter == 0){
			//...with 1st number blank
			num2 = Random.Range(0,13);
			switch(operatorUsed){
				case(0):
				//addition
				math_operator = '+';
				num1 = Random.Range(0,13);
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
				math_operator = '/';
				num1 = Random.Range(num2*2, num2*12);
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
			num1 = Random.Range(1,13);
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
				math_operator = '/';
				num2 = Random.Range(1, num1);
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
			num1 = Random.Range(1, 13);
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
				math_operator = '/';
				num2 = Random.Range(1, num1);
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
			num1 = Random.Range(1, 13);
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
				math_operator = '/';
				num2 = Random.Range(1, num1);
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
		inputText.text = inputText.text + val;
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
			}
			break;
			case(2):
			//operator is blank
			if(math_operator.ToString() == inputText.text){
				//is correct
				pass();
			}else{
				//is incorrect
				inputText.text = "";
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
			}
			break;
		}
	}
	
	//go back to main scene
	public void goBackToMain(){
		SceneManager.LoadScene("main");
	}
}
