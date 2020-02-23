using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    private float timeLeft = 120;
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
    private GameObject cardSpawner; 
    private bool restockCards = false;

    void Update()
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
            StartCoroutine(RestockCards()); 
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
    
    public void AddCard(GameObject card) //called from CardController class
    {
        if (firstCard == null) //Adds first card
        {
            firstCard = card;
        }
        else //Adds second card and checks if both cards match
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
    
    IEnumerator DeactivateCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
        firstCard.SetActive(false);
        secondCard.SetActive(false);
        Reset();
    }
    
    IEnumerator FlipCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
        firstCard.GetComponent<CardController>().FlipCard();
        secondCard.GetComponent<CardController>().FlipCard();
        Reset();
    }
    
    public void DecreaseCardCount()
    {
        _cardsLeft -= 1;
        if (_cardsLeft == 0 && timeLeft > 0)
        {
            restockCards = true; 
        }
    }
    
    IEnumerator RestockCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
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

    bool CheckIfMatch()
    {
        if (firstCard.GetComponent<CardController>().cardID == secondCard.GetComponent<CardController>().cardID)
        {
            pairsMade++;
            DecreaseCardCount();
            return true;
        }

        return false;
    }
    
    public void Reset()
    {
        firstCard = null;
        secondCard = null;
        _canFlip = true;
    }
    
    void gameComplete()
    {
    
    }
}