/*
	English Game Script
	Ryan Mayer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class EnglishGameController : MonoBehaviour
{
	//Buttons
	[SerializeField] Button btn_a, btn_b, btn_c, btn_d,
	btn_e, btn_f, btn_g, btn_h, btn_i, btn_j, btn_k, btn_l,
	btn_m, btn_n, btn_o, btn_p, btn_q, btn_r, btn_s, btn_t,
	btn_u, btn_v, btn_w, btn_x, btn_y, btn_z, btn_yes, btn_no;
	
	//word text field
	[SerializeField] Text wordToGuess;
	
	//win/lose text field
	[SerializeField] Text winlose;
	
	//finish UI
	GameObject finish_ui;
	CanvasGroup finish_group;
	
	//hangman ui
	[SerializeField] Image head;
	[SerializeField] Image body;
	[SerializeField] Image arm_left;
	[SerializeField] Image arm_right;
	[SerializeField] Image leg_left;
	[SerializeField] Image leg_right;
	int part_count = 0;
	
	//array of words from text file
	string[] words;
	//word chosen to guess
	string wordChosen;
	//limits of word size
	[SerializeField] int minWordLength;
	[SerializeField] int maxWordLength;
	//points
	int pointsEarned = 0;
	int rewardPoints = 15;
	//win-lose state
	bool gameWin = false;
	
	//sounds
	public AudioSource confirmSound;
	public AudioSource cancelSound;
	public AudioSource yaySound;
	public AudioSource bgMusic;
	
    // Start is called before the first frame update
    void Start()
    {
		//pause main bg music
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().StopBGMusic();
		//play bg music for hangman
		if(!(bgMusic.isPlaying)){
			bgMusic.Play();
		}
		
		//set body parts to inactive
		head.enabled = false;
		body.enabled = false;
		arm_left.enabled = false;
		arm_right.enabled = false;
		leg_left.enabled = false;
		leg_right.enabled = false;
		
		//get finish UI
		finish_ui = this.gameObject.transform.GetChild(0).GetChild(8).gameObject;
		finish_group = finish_ui.GetComponent<CanvasGroup>();
		//start game with finish ui hidden
		//set alpha to transparent and do not allow interactions
		finish_group.alpha = 0f;
		finish_group.blocksRaycasts = false;
		
		//add listeners to buttons
		btn_a.onClick.AddListener(() => checkGuess('a', btn_a));
		btn_b.onClick.AddListener(() => checkGuess('b', btn_b));
		btn_c.onClick.AddListener(() => checkGuess('c', btn_c));
		btn_d.onClick.AddListener(() => checkGuess('d', btn_d));
		btn_e.onClick.AddListener(() => checkGuess('e', btn_e));
		btn_f.onClick.AddListener(() => checkGuess('f', btn_f));
		btn_g.onClick.AddListener(() => checkGuess('g', btn_g));
		btn_h.onClick.AddListener(() => checkGuess('h', btn_h));
		btn_i.onClick.AddListener(() => checkGuess('i', btn_i));
		btn_j.onClick.AddListener(() => checkGuess('j', btn_j));
		btn_k.onClick.AddListener(() => checkGuess('k', btn_k));
		btn_l.onClick.AddListener(() => checkGuess('l', btn_l));
		btn_m.onClick.AddListener(() => checkGuess('m', btn_m));
		btn_n.onClick.AddListener(() => checkGuess('n', btn_n));
		btn_o.onClick.AddListener(() => checkGuess('o', btn_o));
		btn_p.onClick.AddListener(() => checkGuess('p', btn_p));
		btn_q.onClick.AddListener(() => checkGuess('q', btn_q));
		btn_r.onClick.AddListener(() => checkGuess('r', btn_r));
		btn_s.onClick.AddListener(() => checkGuess('s', btn_s));
		btn_t.onClick.AddListener(() => checkGuess('t', btn_t));
		btn_u.onClick.AddListener(() => checkGuess('u', btn_u));
		btn_v.onClick.AddListener(() => checkGuess('v', btn_v));
		btn_w.onClick.AddListener(() => checkGuess('w', btn_w));
		btn_x.onClick.AddListener(() => checkGuess('x', btn_x));
		btn_y.onClick.AddListener(() => checkGuess('y', btn_y));
		btn_z.onClick.AddListener(() => checkGuess('z', btn_z));
		
		btn_yes.onClick.AddListener(() => reloadScene(gameWin)); //restart game
		btn_no.onClick.AddListener(() => goBackToMain(gameWin)); //back to main menu
		
		//load words file
		words = System.IO.File.ReadAllLines(@"Assets/Text Files/hangman_words.txt");
		//choose a word to guess
		chooseWord(words);
		//show hidden word
		showHiddenWord(wordChosen);
    }

	
	//checks if game is lost
	void Update(){
		string checkWord = removeSpaces(wordToGuess.text);
		int yayCount = 0;
		if(part_count == 6){
			//all parts hanged, lose
			winlose.text = "You Lose";
			wordToGuess.text = wordChosen;
			//show finish UI
			finish_group.alpha = 1f;
			finish_group.blocksRaycasts = true;
		}else if(checkWord == wordChosen){
			//player guessed word, win
			gameWin = true;
			winlose.text = "You Win";
			//yay sound here goes infinitely??
			if(!(yaySound.isPlaying) && yayCount == 0){
				yaySound.Play();
				yayCount++;
			}
			//show finish UI
			finish_group.alpha = 1f;
			finish_group.blocksRaycasts = true;
		}
	}
	
	//reload scene
	public void reloadScene(bool gameWin){
		if(gameWin){
			//reload from win state, save points
			GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>().AddPoints(15);
		}
		gameWin = false;
		SceneManager.LoadScene("english");
	}
	
	//go back to main scene
	public void goBackToMain(bool gameWin){
		if(gameWin){
			//quit from win state, save points
			GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>().AddPoints(15);
		}
		gameWin = false;
		//play main bg music
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayBGMusic();
		SceneManager.LoadScene("main");
	}

	//choose a word to guess
	void chooseWord(string[] words){
		bool chosen = false;
		do{
			//get random word
			int randWordIndex = Random.Range(0,words.Length);
			//make sure the word fits under min/max constraints
			if(words[randWordIndex].Length > minWordLength && words[randWordIndex].Length < maxWordLength){
				//word is chosen, continue
				wordChosen = words[randWordIndex];
				chosen = true;
			}
			
		}while(chosen == false);
	}
	
	//show the word chosen as underscores
	void showHiddenWord(string word){
		int wordLength = word.Length;
		string hiddenWord = "";
		for(int i = 0; i < wordLength; i++){
			hiddenWord = hiddenWord + "_";
			if(i != wordLength-1){
				hiddenWord = hiddenWord + " ";
			}
		}
		wordToGuess.text = hiddenWord;
	}
	
	//check the guess
	void checkGuess(char guess, Button btn){
		//set the guessed letter button to not active
		btn.interactable = false;
		if(wordChosen.Contains(guess.ToString())){
			//the letter is in the word
			confirmSound.Play();
			//get indices of the guessed letter in wordChosen
			List<int> indicesList = new List<int>();
			for(int i = 0; i < wordChosen.Length; i++){
				if(wordChosen[i] == guess){
					indicesList.Add(i);
				}
			}
			//update the hiddenword
			wordToGuess.text = updateHiddenWord(indicesList.ToArray(), guess, wordToGuess.text);
		}else{
			//the letter is not in the word
			cancelSound.Play();
			updateMan(part_count);
			part_count++;
		}
	}
	
	//update hidden word at the indices indicates to show the correctly guessed character
	string updateHiddenWord(int[] indices, char guess, string hiddenWord){
		//remove spaces from hiddenword
		string temp = "";
		for(int i = 0; i < hiddenWord.Length; i++){
			if(!(char.IsWhiteSpace(hiddenWord[i]))){
				temp = temp + hiddenWord[i];
			}
		}
		//update indices
		string updated = "";
		for(int i = 0; i < temp.Length; i++){
			if(indices.Contains(i)){
				updated = updated + guess;
			}else{
				updated = updated + temp[i];
			}
		}
		//replace spaces
		string output = "";
		for(int i = 0; i < updated.Length; i++){
			output = output + updated[i];
			if(i != updated.Length-1){
				output = output + " ";
			}
		}
		//return
		return output;
	}
	
	//remove spaces from hiddenword
	string removeSpaces(string word){
		string temp = "";
		for(int i = 0; i < word.Length; i++){
			if(!(word[i] == ' ')){
				temp = temp + word[i];
			}
		}
		return temp;
	}
	
	//incorrect answer, add body part
	void updateMan(int part){
		switch(part){
			case(0):
			//head
			head.enabled = true;
			break;
			case(1):
			//body
			body.enabled = true;
			break;
			case(2):
			//arm_left
			arm_left.enabled = true;
			break;
			case(3):
			//arm_right
			arm_right.enabled = true;
			break;
			case(4):
			//leg_left
			leg_left.enabled = true;
			break;
			case(5):
			//leg_right
			leg_right.enabled = true;
			break;
		}
	}
}
