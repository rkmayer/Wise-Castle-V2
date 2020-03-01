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
	btn_u, btn_v, btn_w, btn_x, btn_y, btn_z;
	
	//word text field
	[SerializeField] Text wordToGuess;
	[SerializeField] GameObject hangman_ui;
	[SerializeField] CanvasGroup hangman_group;
	
	//array of words from text file
	string[] words;
	//word chosen to guess
	string wordChosen;
	//limits of word size
	[SerializeField] int minWordLength;
	[SerializeField] int maxWordLength;
	
    // Start is called before the first frame update
    void Start()
    {
		//get hangman ui
		
		
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
		
		//load text file (10000 common english words)
		words = System.IO.File.ReadAllLines(@"Assets/Text Files/hangman_words.txt");
		//choose a word to guess
		chooseWord(words);
		//show hidden word
		showHiddenWord(wordChosen);
        
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
}
