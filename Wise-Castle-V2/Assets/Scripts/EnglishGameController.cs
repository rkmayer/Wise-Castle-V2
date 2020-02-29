using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnglishGameController : MonoBehaviour
{
	//Buttons
	[SerializeField] Button btn_a, btn_b, btn_c, btn_d,
	btn_e, btn_f, btn_g, btn_h, btn_i, btn_j, btn_k, btn_l,
	btn_m, btn_n, btn_o, btn_p, btn_q, btn_r, btn_s, btn_t,
	btn_u, btn_v, btn_w, btn_x, btn_y, btn_z;
	
	//word text field
	[SerializeField] Text wordToGuess;
	
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
		//add listeners to buttons
		btn_a.onClick.AddListener(() => checkGuess('a'));
		btn_b.onClick.AddListener(() => checkGuess('b'));
		btn_c.onClick.AddListener(() => checkGuess('c'));
		btn_d.onClick.AddListener(() => checkGuess('d'));
		btn_e.onClick.AddListener(() => checkGuess('e'));
		btn_f.onClick.AddListener(() => checkGuess('f'));
		btn_g.onClick.AddListener(() => checkGuess('g'));
		btn_h.onClick.AddListener(() => checkGuess('h'));
		btn_i.onClick.AddListener(() => checkGuess('i'));
		btn_j.onClick.AddListener(() => checkGuess('j'));
		btn_k.onClick.AddListener(() => checkGuess('k'));
		btn_l.onClick.AddListener(() => checkGuess('l'));
		btn_m.onClick.AddListener(() => checkGuess('m'));
		btn_n.onClick.AddListener(() => checkGuess('n'));
		btn_o.onClick.AddListener(() => checkGuess('o'));
		btn_p.onClick.AddListener(() => checkGuess('p'));
		btn_q.onClick.AddListener(() => checkGuess('q'));
		btn_r.onClick.AddListener(() => checkGuess('r'));
		btn_s.onClick.AddListener(() => checkGuess('s'));
		btn_t.onClick.AddListener(() => checkGuess('t'));
		btn_u.onClick.AddListener(() => checkGuess('u'));
		btn_v.onClick.AddListener(() => checkGuess('v'));
		btn_w.onClick.AddListener(() => checkGuess('w'));
		btn_x.onClick.AddListener(() => checkGuess('x'));
		btn_y.onClick.AddListener(() => checkGuess('y'));
		btn_z.onClick.AddListener(() => checkGuess('z'));
		
		//load text file (10000 common english words)
		words = System.IO.File.ReadAllLines(@"Assets/Text Files/10000_words.txt");
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
			int randWordIndex = Random.Range(0,10000);
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
	void checkGuess(char guess){
		if(wordChosen.Contains(guess.ToString())){
			//the letter is in the word
			
		}else{
			//the letter is not in the word
		}
	}
	
	//update the hidden word
	void updateHiddenWord(char guess){
		string hiddenWord = "";
		//TODO: put characters of wordToGuess into hiddenword, unless index is of the guessed letter in the wordchosen (?)
	}
}
