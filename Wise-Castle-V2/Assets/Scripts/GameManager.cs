/*
* Script File: GameManager.cs
* Developer: Jenna Magbanua (for Wise Castle)
* Purpose: Chemsitry Game Component
* Description:  
*      It controls the major components/actions for the game  
*      Handles the card matching, points increase, flipping, end screen, etc.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    private float timeLeft = 60;
    private bool timerRun = true;
    
    private GameObject firstCard = null;
    private GameObject secondCard = null;
    private ArrayList cardArray = new ArrayList(); 
    
    private int _cardsLeft = 12;
    private bool _canFlip = true;
    private float _timeBetweenFlips = 0.75f;
    
    [SerializeField]
    private Text pairsText; 
    private int pairsMade = 0; 
    
    [SerializeField]
    private GameObject cardSpawner;//access to the card spawner object to spawn new cards
    private bool restockCards = false;
    
    [SerializeField]
    private GameObject endCanvas;
    [SerializeField]
    private Button finishBtn;
    [SerializeField]
    private Text endText;
    
    //sounds
	public AudioSource correctSound; //get a match
	public AudioSource yaySound; //get all matches of a round 
	public AudioSource bgMusic;
    
    void Awake() //occurs before game starts
    {
        finishBtn.onClick.AddListener(goBackToMain);
        endCanvas.SetActive(false);	
    }
    
    void Start()//once the game begins 
    {
        //stop main bg music
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().StopBGMusic();
        bgMusic.Play();
    }

    void Update() //runs every frame 
    {
        if (timerRun)
        {
            if (timeLeft >= 0.0)
            {
                timerText.text = Mathf.Round(timeLeft).ToString();
            }
            else
            {
                timerRun = false;
                gameComplete();
            }
            timeLeft -= Time.deltaTime;
        }
        
        if(restockCards == true)
        {
            restockCards = false;
            StartCoroutine(RestockCards()); //needs to be done after a period of time so allows last match to disappear
        }
        
        pairsText.text = "Pairs: " + pairsMade;
    }
    
    public bool canFlip
    {
        get
        {
            return _canFlip;
        }
        set
        {
            _canFlip = value;
        }
    }
    
    public void AddCard(GameObject card) //called from CardController.cs
    {
        if (firstCard == null)//add first card
        {
            firstCard = card;
        }
        else//adds second card and checks if card id's match
        {
            secondCard = card;
            _canFlip = false;
            if (CheckIfMatch())
            {
                DecreaseCardCount();
                StartCoroutine(DeactivateCards());
            }
            else
            {
                StartCoroutine(FlipCards());
            }
        }
    }
    
    IEnumerator DeactivateCards()//removal of cards (for when they're a match)
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
        firstCard.SetActive(false);
        secondCard.SetActive(false);
        Reset();
    }
    
    IEnumerator FlipCards()//flipping of cards 
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
        firstCard.GetComponent<CardController>().FlipCard();
        secondCard.GetComponent<CardController>().FlipCard();
        Reset();
    }
    
    public void DecreaseCardCount()//decreasing the card count (for card restock)
    {
        _cardsLeft -= 1;
        
        if (_cardsLeft == 0 && timeLeft > 0)
        {
            restockCards = true; 
        }
    }
    
    IEnumerator RestockCards()//spawning new set of cards on screen 
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
        yaySound.Play();
        cardSpawner.GetComponent<CardSpawner>().SpawningCards();
        cardsLeft = 12;
    }

    public int cardsLeft
    {
        get
        {
            return _cardsLeft;
        }
        set
        {
            _cardsLeft = value;
        }
    }

    bool CheckIfMatch()//checking if the cards' are a pair 
    {
        if (firstCard.GetComponent<CardController>().cardID == secondCard.GetComponent<CardController>().cardID)
        {
            pairsMade++;
            DecreaseCardCount();
            correctSound.Play();
            return true;
        }

        return false;
    }
    
    public void Reset()//resetting the cards (for when they're not a match)
    {
        firstCard = null;
        secondCard = null;
        _canFlip = true;
    }
    
    void gameComplete()//gameComplete --> after timer runs out 
    {
        endText.text = "Points Rewarded: " + pairsMade + "!";
        endCanvas.SetActive(true);
        
    }
    
    public void goBackToMain()//end screen button --> return back to main
    {
		//play main bg music
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayBGMusic();
		//save points
		GameObject.FindGameObjectWithTag("Points").GetComponent<PointScript>().AddPoints(pairsMade);
		//switch to main menu
		SceneManager.LoadScene("main");
	}
}